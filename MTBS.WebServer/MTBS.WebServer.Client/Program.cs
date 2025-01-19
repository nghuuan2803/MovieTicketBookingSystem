using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using MTBS.WebServer.Client.Mediators;

namespace MTBS.WebServer.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddFluentUIComponents();

            var config = builder.Configuration;
            var apiBaseAddress = config["ApiSettings:BaseAddress"];
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiBaseAddress)
            };
            builder.Services.AddScoped(sp => httpClient);

            builder.Services.AddScoped<TicketStateMediator>();

            await builder.Build().RunAsync();
        }
    }
}
