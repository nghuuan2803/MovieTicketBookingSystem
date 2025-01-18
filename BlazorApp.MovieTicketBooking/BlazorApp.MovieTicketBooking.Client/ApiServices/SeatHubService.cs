using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorApp.MovieTicketBooking.Client.ApiServices
{
    public class SeatHubService
    {
        private readonly HubConnection _hubConnection;

        public event Action<int, int, string> OnSeatStatusChanged;
        public string HubConnectionId => _hubConnection.ConnectionId;
        public SeatHubService(NavigationManager navigationManager, IConfiguration config)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri($"{config["ApiSettings:BaseAddress"]}seathub"))
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<int, int, string>("ReceiveSeatStatus", (veId, status, hubId) =>
            {
                OnSeatStatusChanged?.Invoke(veId, status, hubId);
                Console.WriteLine($"Nhận được tín hiệu đặt vé: {veId}-{status}-{hubId}");
            });
        }

        public async Task ConnectToHub()
        {
            await _hubConnection.StartAsync();
            Console.WriteLine($"Current HubConnection State: {_hubConnection.State}");
        }

        public async Task DisconnectFromHub()
        {
            await _hubConnection.StopAsync();
        }
        public async Task JoinGroup(string xuatChieuId)
        {
            await _hubConnection.SendAsync("JoinGroup", xuatChieuId);
            Console.WriteLine($"Đã tham gia nhóm: {xuatChieuId}");
        }
        public async Task LeaveGroup(string xuatChieuId)
        {
            await _hubConnection.SendAsync("LeaveGroup", xuatChieuId);
            Console.WriteLine($"Đã tham gia nhóm: {xuatChieuId}");
        }
    }

}
