using Microsoft.AspNetCore.SignalR;

namespace MTBS.WebApp.Hubs
{
    public class SeatHub : Hub
    {
        public async Task JoinGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
            Console.WriteLine($"Client {Context.ConnectionId} đã tham gia nhóm {groupId}");
        }

        public async Task LeaveGroup(string groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
            Console.WriteLine($"Client {Context.ConnectionId} đã rời khỏi nhóm {groupId}");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Thực hiện các hành động khi client ngắt kết nối, nếu cần
            await base.OnDisconnectedAsync(exception);
        }
    }
}
