using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTBS.Domain.SampleModels;
using MTBS.Infrastructure;
using MTBS.Shared.SimpleDTOs;
using Newtonsoft.Json;

namespace MTBS.WebApp.SimpleAPI
{
    //[Route("api/[Controller]")]
    //[ApiController]
    //public class PhongChieuController : GenericController<PhongChieu>
    //{
    //    public PhongChieuController(AppDbContext dbContext) : base(dbContext)
    //    {
    //    }

    //    public async override Task<IActionResult> GetById(int id, CancellationToken cancellation)
    //    {
    //        return Ok(await dbSet.Include(p => p.DsGhe).FirstOrDefaultAsync(p => p.Id == id, cancellation));
    //    }

    //    [HttpPost("create")]
    //    public async Task<IActionResult> CreatePhongChieu([FromBody] PhongChieuRequest request)
    //    {
    //        if (request == null) return BadRequest("Invalid data");

    //        // Sử dụng Execution Strategy để hỗ trợ các thao tác retry
    //        var strategy = db.Database.CreateExecutionStrategy();

    //        try
    //        {
    //            // Thực hiện giao dịch trong chiến lược tái thực thi (retry strategy)
    //            await strategy.ExecuteAsync(async () =>
    //            {
    //                using var transaction = await db.Database.BeginTransactionAsync();

    //                try
    //                {
    //                    var LayoutSerialize = JsonConvert.SerializeObject(request.Layout);
    //                    var metadata = JsonConvert.SerializeObject(request.Metadata);
    //                    // Tạo phòng chiếu
    //                    var phongChieu = new PhongChieu
    //                    {
    //                        Ten = request.Ten,
    //                        SoHang = request.SoHang,
    //                        SoCot = request.SoCot,
    //                        Layout = request.Layout,
    //                        Metadata = metadata,
    //                        HeSoGia = request.HeSoGia
    //                    };

    //                    db.PhongChieus.Add(phongChieu);
    //                    await db.SaveChangesAsync();

    //                    // Parse sơ đồ ghế (JSON hoặc chuỗi ma trận)

    //                    int[,] layout = JsonConvert.DeserializeObject<int[,]>(request.Layout);
    //                    if (layout == null || layout.Length == 0)
    //                        throw new Exception("Không có ghế");
    //                    // Tạo danh sách ghế
    //                    var dsGhe = new List<Ghe>();
    //                    for (int hang = 0; hang < layout.GetLength(0); hang++)
    //                    {
    //                        int tenCot = layout.GetLength(1) - CountZero(layout, hang);
    //                        // Xác định tên hàng (A, B, C,...)
    //                        var tenHang = (char)('A' + hang);

    //                        // Lặp qua các cột và đảo ngược thứ tự ghế
    //                        for (int cot = 0; cot < layout.GetLength(1); cot++)
    //                        {
    //                            var loaiGhe = layout[hang, cot];

    //                            // Bỏ qua nếu là ghế trống (loại 0)
    //                            if (loaiGhe == 0) continue;

    //                            // Tạo tên ghế theo thứ tự ngược
    //                            dsGhe.Add(new Ghe
    //                            {
    //                                SoGhe = $"{tenHang}{tenCot--}", // Đảo ngược thứ tự tên ghế
    //                                LoaiGhe = loaiGhe,
    //                                HeSoGia = loaiGhe == 2 ? 1.5 : 1.0, // Ghế đôi có hệ số giá cao hơn
    //                                PhongChieuId = phongChieu.Id,
    //                                Hang = hang,
    //                                Cot = cot,
    //                            });
    //                        }
    //                    }

    //                    db.Ghes.AddRange(dsGhe);
    //                    await db.SaveChangesAsync();

    //                    await transaction.CommitAsync();
    //                }
    //                catch (Exception ex)
    //                {
    //                    await transaction.RollbackAsync();
    //                    throw new Exception($"Lỗi khi tạo phòng chiếu: {ex.Message}");
    //                }
    //            });

    //            return Ok(new { Message = "Phòng chiếu và ghế được tạo thành công!" });
    //        }
    //        catch (Exception ex)
    //        {
    //            return StatusCode(500, $"Lỗi khi tạo phòng chiếu: {ex.Message}");
    //        }
    //    }

    //    private int CountZero(int[,] arr, int row)
    //    {
    //        int count = 0;
    //        for (int i = 0; i < arr.GetLength(1); i++)
    //        {
    //            if (arr[row, i] == 0) count++;
    //        }
    //        return count;
    //    }
    //}
}
