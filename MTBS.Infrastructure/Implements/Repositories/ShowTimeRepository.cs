using Microsoft.EntityFrameworkCore;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure.Implements.Repositories
{
    public class ShowTimeRepository : GenericRepository<ShowTime>, IShowTimeRepository
    {
        public ShowTimeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<ShowTime> FindAsync(Expression<Func<ShowTime, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return _dbContext.ShowTimes.Include(p => p.Tickets)
                .FirstOrDefaultAsync(predicate, cancellationToken)!;
        }

        public override async Task<IEnumerable<ShowTime>> GetAllAsync(
            Expression<Func<ShowTime, bool>> predicate = null!,
            CancellationToken cancellationToken = default)
        {
            return predicate == null ?
             await _dbContext.Set<ShowTime>()
                   .AsNoTracking()
                   .ToListAsync(cancellationToken)
             :
             await _dbContext.Set<ShowTime>()
                 .Where(predicate)
                 .AsNoTracking()
                 .ToListAsync(cancellationToken);
        }

        public async Task<Dictionary<DateTime, List<ShowTime>>> GetSchedule()
        {
            var today = DateTime.Now.Date;
            var next7Days = today.AddDays(7);

            // Truy vấn lịch chiếu từ DbSet
            var showtimes = await _dbContext.ShowTimes.AsNoTracking()
                .Where(st => !st.IsCanceled && !st.IsDeleted && st.BeginAt.Date >= today && st.BeginAt.Date < next7Days)
                .ToListAsync();

            // Tạo danh sách tất cả các ngày trong 7 ngày tiếp theo
            var allDates = Enumerable.Range(0, 7).Select(offset => today.AddDays(offset)).ToList();

            // Gom nhóm lịch chiếu theo ngày và điền các ngày không có suất chiếu với danh sách rỗng
            var groupedShowtimes = allDates.ToDictionary(
                date => date,
                date => showtimes.Where(st => st.BeginAt.Date == date).ToList()
            );

            return groupedShowtimes;
        }

    }
}
