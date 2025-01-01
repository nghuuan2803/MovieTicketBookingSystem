using MTBS.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure.MockData.MockRepos
{
    public class MockTable(AppDbContext _dbContext)
    {
        public TestTable? GetRecord(string id)
        {
            return _dbContext.TestTables.Find(id);
        }
        public void Insert(TestTable record)
        {
            _dbContext.TestTables.Add(record);
            _dbContext.SaveChanges();
        }
        public IEnumerable<TestTable> GetAll()
        {
            return _dbContext.TestTables.ToList();
        }
    }
}
