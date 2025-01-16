using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MTBS.Infrastructure;
using MTBS.WebApp.Hubs;

namespace MTBS.WebApp.BackgroudTaskServices
{
    public class AutoReleaseSeatService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<SeatHub> _hubContext;
        private readonly TimeSpan _timeout = TimeSpan.FromMinutes(1); // Thời gian giữ ghế tối đa

        public AutoReleaseSeatService(IServiceProvider serviceProvider, IHubContext<SeatHub> hubContext)
        {
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;
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
                    var expiredSeats = await db.Ves
                        .Where(v => v.TrangThai == 1 && v.CapNhatLuc < timeoutDateTime)
                        .ToListAsync(stoppingToken);


                    //Gọi hub để thông báo nhả từng ghế cho client
                    foreach (var ve in expiredSeats)
                    {
                        ve.TrangThai = 0; // Nhả ghế
                        ve.NguoiGiu = string.Empty; // Xóa mã kết nối
                        ve.CapNhatLuc = DateTime.Now;

                        // Gửi thông báo real-time cho các client
                        //await _hubContext.Clients.Group(ve.XuatChieuId.ToString()).SendAsync("CapNhatTrangThaiGhe", new { VeId = ve.Id, TrangThai = 0 }, stoppingToken);
                        await _hubContext.Clients.Group(ve.XuatChieuId.ToString()).SendAsync("ReceiveSeatStatus", ve.Id, 0,string.Empty);
                    }

                    if (expiredSeats.Any())
                    {
                        await db.SaveChangesAsync(stoppingToken);
                    }
                }

                // Kiểm tra mỗi 1 phút
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
