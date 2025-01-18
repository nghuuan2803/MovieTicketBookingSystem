using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MTBS.Infrastructure;
using MTBS.Shared.SimpleDTOs;
using MTBS.WebApp.Hubs;

//namespace MTBS.WebApp.SimpleAPI
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class VeController(AppDbContext db, IHubContext<SeatHub> _hubContext) : ControllerBase
//    {
//        [HttpPost("giu-ve")]
//        public async Task<IActionResult> ChonGhe([FromBody] ChonGheRequest request)
//        {
//            var ve = await db.Ves
//            .FirstOrDefaultAsync(v => v.Id == request.VeId && v.XuatChieuId == request.XuatChieuId);

//            if (ve == null)
//                return BadRequest("Ghế không tồn tại.");

//            if (ve.TrangThai == 2)
//                return BadRequest("Ghế đã được đặt.");

//            if (ve.TrangThai == 1)
//                return BadRequest("Ghế đang được giữ bởi người khác.");

//            ve.TrangThai = 1; // Đang giữ chỗ
//            ve.NguoiGiu = request.HubConnectionId; // Lưu người dùng giữ chỗ
//            ve.CapNhatLuc = DateTime.Now;
//            await db.SaveChangesAsync();

//            await _hubContext.Clients.Group(ve.XuatChieuId.ToString()).SendAsync("ReceiveSeatStatus", ve.Id, 1, request.HubConnectionId);
//            //await _hubContext.Clients.All.SendAsync("ReceiveSeatStatus", ve.Id, 1, request.HubConnectionId);
            

//            return Ok(ve);
//        }

//        [HttpPost("nha-ve")]
//        public async Task<IActionResult> NhaGhe([FromBody] NhaGheRequest request)
//        {
//            var ve = await db.Ves
//            .FirstOrDefaultAsync(v => v.Id == request.VeId && v.XuatChieuId == request.XuatChieuId);

//            if (ve == null)
//                return BadRequest("Ghế không tồn tại.");

//            if (ve.TrangThai == 0)
//                return BadRequest("Ghế chưa được chọn.");

//            if (ve.TrangThai == 2)
//                return BadRequest("Ghế đã được đặt.");

//            if (ve.TrangThai == 1 && ve.NguoiGiu != request.HubConnectionId)
//                return BadRequest("Ghế đang được giữ bởi người khác.");

//            ve.TrangThai = 0;
//            ve.NguoiGiu = string.Empty;
//            ve.CapNhatLuc = DateTime.Now;

//            await db.SaveChangesAsync();

//            //await _hubContext.Clients.All.SendAsync("ReceiveSeatStatus", ve.Id, 0, request.HubConnectionId);
//            await _hubContext.Clients.Group(ve.XuatChieuId.ToString()).SendAsync("ReceiveSeatStatus", ve.Id, 0, request.HubConnectionId);
            

//            return Ok(ve);
//        }
//    }
//}
