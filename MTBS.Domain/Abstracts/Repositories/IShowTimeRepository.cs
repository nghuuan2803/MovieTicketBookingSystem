using MTBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Abstracts.Repositories
{
    public interface IShowTimeRepository : IGenericRepository<ShowTime>
    {
        Task<Dictionary<DateTime, List<ShowTime>>> GetSchedule();
    }
}
