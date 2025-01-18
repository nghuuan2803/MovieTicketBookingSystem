using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MTBS.Infrastructure;

namespace MTBS.WebServer
{
    public class AutoReleaseTicketService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<TicketHub> _hubContext;
        private readonly TimeSpan _timeout = TimeSpan.FromMinutes(1); // Thời gian giữ ghế tối đa

        public AutoReleaseTicketService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _hubContext = serviceProvider.GetRequiredService<IHubContext<TicketHub>>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var currentDateTime = DateTime.Now;
                    var timeoutDateTime = currentDateTime - _timeout;
                    //lấy danh sách vé hết hạn giữ
                    var expiredSeats = await db.Tickets
                        .Where(v => v.Status == 1 && v.UpdatedAt < timeoutDateTime)
                        .ToListAsync(stoppingToken);


                    //Gọi hub để thông báo nhả từng ghế cho client
                    foreach (var ticket in expiredSeats)
                    {
                        ticket.Status = 0; // Nhả ghế
                        ticket.HoldBy = string.Empty; // Xóa mã kết nối
                        ticket.UpdatedAt = DateTime.Now;

                        // Gửi thông báo real-time cho các client
                        
                        await _hubContext.Clients.Group(ticket.ShowTimeId.ToString()).SendAsync("ReceiveSeatStatus", ticket.Id, 0, string.Empty);
                    }

                    if (expiredSeats.Any())
                    {
                        await db.SaveChangesAsync(stoppingToken);
                    }
                }

                // Kiểm tra mỗi 30s
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
