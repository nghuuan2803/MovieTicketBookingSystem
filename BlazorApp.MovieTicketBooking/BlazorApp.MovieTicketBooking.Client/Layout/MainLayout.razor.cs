using BlazorApp.MovieTicketBooking.Client.ApiServices;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.MovieTicketBooking.Client.Layout
{
    public partial class MainLayout
    {
        [Inject]
        public SeatHubService SeatHubService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(10);
            await SeatHubService.ConnectToHub();
        }
        public async ValueTask DisposeAsync()
        {        
            await SeatHubService.DisconnectFromHub();
        }
    }
}
