using BlazorApp.MovieTicketBooking.Client.ApiServices;
using BlazorApp.MovieTicketBooking.Client.StateManagers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
namespace BlazorApp.MovieTicketBooking.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();

            var config = builder.Configuration;
            var apiBaseAddress = config["ApiSettings:BaseAddress"];
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiBaseAddress)
            };
            builder.Services.AddScoped(sp => httpClient);
            builder.Services.AddScoped<XuatChieuService>();
            builder.Services.AddScoped<SeatHubService>();
            builder.Services.AddScoped<VeStateManager>();
            await builder.Build().RunAsync();
        }
    }
}
