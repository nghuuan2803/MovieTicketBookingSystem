using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTBS.Domain.SampleModels;
using MTBS.Infrastructure;
using MTBS.Shared.SimpleDTOs;
using Newtonsoft.Json;

//namespace MTBS.WebApp.SimpleAPI
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class XuatChieuController : GenericController<XuatChieu>
//    {
//        public XuatChieuController(AppDbContext dbContext) : base(dbContext)
//        {
//        }

//        [HttpPost("create-xuat-chieu")]
//        public async Task<IActionResult> CreateXuatChieu([FromBody] XuatChieuRequest request)
//        {
//            if (request == null) return BadRequest("Invalid data");

//            var strategy = db.Database.CreateExecutionStrategy();

//            try
//            {
//                // Thực hiện toàn bộ logic trong chiến lược thực thi
//                await strategy.ExecuteAsync(async () =>
//                {
//                    using var transaction = await db.Database.BeginTransactionAsync();

//                    // Lấy thông tin phòng chiếu
//                    var phongChieu = await db.PhongChieus
//                        .Include(pc => pc.DsGhe) // Lấy danh sách ghế của phòng chiếu
//                        .FirstOrDefaultAsync(pc => pc.Id == request.PhongChieuId);

//                    if (phongChieu == null)
//                        throw new Exception($"Phòng chiếu với ID {request.PhongChieuId} không tồn tại.");

//                    if (phongChieu.DsGhe == null || !phongChieu.DsGhe.Any())
//                        throw new Exception("Phòng chiếu không có ghế.");

//                    // Tạo xuất chiếu
//                    var xuatChieu = new XuatChieu
//                    {
//                        GioChieu = request.GioChieu,
//                        ThoiLuong = request.ThoiLuong,
//                        PhimId = request.PhimId,
//                        PhongChieuId = request.PhongChieuId
//                    };
//                    xuatChieu.SetGioKetThuc();

//                    db.XuatChieus.Add(xuatChieu);
//                    await db.SaveChangesAsync();

//                    // Tạo danh sách vé dựa trên ghế
//                    var dsVe = phongChieu.DsGhe.Select(ghe => new Ve
//                    {
//                        TrangThai = 0, // 0: Open
//                        Gia = phongChieu.HeSoGia * (ghe.LoaiGhe == 2 ? 1.5 : 1.0), // Giá theo loại ghế
//                        XuatChieuId = xuatChieu.Id,
//                        GheId = ghe.Id
//                    }).ToList();

//                    db.Ves.AddRange(dsVe);
//                    await db.SaveChangesAsync();

//                    await transaction.CommitAsync();
//                });

//                return Ok(new
//                {
//                    Message = "Xuất chiếu và vé được tạo thành công!"
//                });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Lỗi khi tạo xuất chiếu: {ex.Message}");
//            }
//        }

//        public override async Task<IActionResult> Get(CancellationToken cancellation)
//        {
//            return Ok(await dbSet.ToListAsync(cancellation));
//        }

//        public override async Task<IActionResult> GetById(int id, CancellationToken cancellation)
//        {
//            var data = await dbSet.Include(p => p.DsVe).ThenInclude(p => p.Ghe)
//                .Include(p => p.Phim)
//                .Include(p => p.PhongChieu)
//                .FirstOrDefaultAsync(p => p.Id == id, cancellation);
//            var metadata = JsonConvert.DeserializeObject<Metadata>(data.PhongChieu.Metadata);
//            var dto = new XuatChieuResponse
//            {
//                XuatChieuId = data.Id,
//                PhongChieuId = data.PhongChieuId,
//                TenPhong = data.PhongChieu.Ten,
//                PhimId = data.PhimId,
//                TenPhim = data.Phim.Name,
//                GioChieu = data.GioChieu,
//                GioKetThuc = (DateTime)data.GioKetThuc,
//                Layout = data.PhongChieu.Layout,
//                Metadata = metadata,
//                DsVe = data.DsVe,
//            };
//            return Ok(dto);
//        }
//    }
//}
