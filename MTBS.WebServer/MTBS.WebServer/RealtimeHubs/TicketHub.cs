using Microsoft.AspNetCore.SignalR;

namespace MTBS.WebServer
{
    public class TicketHub : Hub
    {
        public async Task JoinGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        }

        public async Task LeaveGroup(string groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Thực hiện các hành động khi client ngắt kết nối, nếu cần
            await base.OnDisconnectedAsync(exception);
        }
    }
}
