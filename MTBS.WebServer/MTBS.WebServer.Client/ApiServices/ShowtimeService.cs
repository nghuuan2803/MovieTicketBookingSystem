using MTBS.Domain.Entities;
using System.Net.Http.Json;

namespace MTBS.WebServer.Client.ApiServices
{
    public class ShowTimeService
    {
        private readonly HttpClient _httpClient;

        public ShowTimeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ShowTime?> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync("api/ShowTimes/"+id);
            response.EnsureSuccessStatusCode();
            var showtime = await response.Content.ReadFromJsonAsync<ShowTime>();
            return showtime;
        }

        public async Task<IEnumerable<ShowTime>?> GetSchedule()
        {
            var response = await _httpClient.GetAsync("api/ShowTimes");
            response.EnsureSuccessStatusCode();
            var showtimes = await response.Content.ReadFromJsonAsync<IEnumerable<ShowTime>>();
            return showtimes;
        }
    }
}
