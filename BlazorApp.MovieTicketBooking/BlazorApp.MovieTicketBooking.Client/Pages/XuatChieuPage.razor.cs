using BlazorApp.MovieTicketBooking.Client.ApiServices;
using BlazorApp.MovieTicketBooking.Client.StateManagers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MTBS.Domain.SampleModels;
using MTBS.Shared.SimpleDTOs;
using Newtonsoft.Json;

namespace BlazorApp.MovieTicketBooking.Client.Pages
{
    public partial class XuatChieuPage
    {
        bool loading = true;
        Ve[,] arrVe;

        public int Id { get; set; } = 1;
        string hubId;

        Metadata metadata;

        [Inject]
        public VeStateManager VeStateManager { get; set; }

        [Inject]
        public XuatChieuService? Service { get; set; }

        [Inject]
        public SeatHubService SeatHubService { get; set; }

        public XuatChieuResponse? Data { get; set; }

        public int[,] Layout { get; set; }

        private List<Ve> VeDaChon = new();

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(100);
            await LoadDataAsync();
            // ủy thác hàm cho stateManager làm hộ
            SeatHubService.OnSeatStatusChanged += HandleSeatStatusChanged;

            // tham gia group kết nối
            await SeatHubService.JoinGroup(Data.XuatChieuId.ToString()); 
            hubId = SeatHubService.HubConnectionId;

            // set dữ liệu cho state manager
            VeStateManager.SetData(Data.DsVe);
            loading = false;
        }

        private async Task LoadDataAsync()
        {
            loading = true;
            Data = await Service.GetXuatChieu(Id);
            Layout = JsonConvert.DeserializeObject<int[,]>(Data.Layout);
            metadata = Data.Metadata;
            TaoMaTranGhe();
            loading = false;
        }
        private void TaoMaTranGhe()
        {
            List<Ve> dsVe = Data.DsVe.ToList();
            int row = Layout.GetLength(0), col = Layout.GetLength(1);
            int index = 0;
            arrVe = new Ve[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (Layout[i, j] != 0)
                    {
                        arrVe[i, j] = dsVe[index];
                        index++;
                    }
                }
            }
            int count = index;
        }
        private async Task HandleSeatSelect(Ve ve)
        {
            if (ve.TrangThai == 0) // Chọn vé
            {
                await Service.GiuVe(new ChonGheRequest
                {
                    XuatChieuId = Data.XuatChieuId,
                    VeId = ve.Id,
                    HubConnectionId = SeatHubService.HubConnectionId
                });
            }
            else if (ve.TrangThai == 1) // Nhả vé
            {
                await Service.NhaVe(new NhaGheRequest
                {
                    XuatChieuId = Data.XuatChieuId,
                    VeId = ve.Id,
                    HubConnectionId = SeatHubService.HubConnectionId
                });
            }
        }
        public async ValueTask DisposeAsync()
        {
            // Hủy đăng ký sự kiện khi component bị hủy
            SeatHubService.OnSeatStatusChanged -= HandleSeatStatusChanged;

            // thoát group
            await SeatHubService.LeaveGroup(Data.XuatChieuId.ToString());
        }

        private void HandleSeatStatusChanged(int veId, int status, string hubId)
        {
            VeStateManager.UpdateVeState(veId, status, hubId);
            Console.WriteLine("[XuatChieuPage]Thread ID: " + Environment.CurrentManagedThreadId);
        }
    }
}
