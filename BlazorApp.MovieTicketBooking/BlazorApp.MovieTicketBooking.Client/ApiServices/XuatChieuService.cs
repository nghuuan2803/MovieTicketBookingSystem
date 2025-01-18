using MTBS.Shared.SimpleDTOs;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorApp.MovieTicketBooking.Client.ApiServices
{
    public class XuatChieuService(HttpClient _http)
    {
        public async Task<XuatChieuResponse> GetXuatChieu(int id)
        {
            var response = await _http.GetFromJsonAsync<XuatChieuResponse>("api/XuatChieu/" + id);
            return response;
        }

        public async Task<int> GiuVe(ChonGheRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Ve/giu-ve", request);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "||" + ex.StackTrace);
                return 0;
            }

        }
        public async Task<int> NhaVe(NhaGheRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/Ve/nha-ve", request);
            if (response.IsSuccessStatusCode)
            {
                return 0;
            }
            return 1;
        }
    }
}
