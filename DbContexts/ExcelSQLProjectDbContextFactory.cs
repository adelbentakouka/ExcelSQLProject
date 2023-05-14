using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSQLProject.DbContexts
{
    public class ExcelSQLProjectDbContextFactory
    {
        private readonly string _connectionString;

        public ExcelSQLProjectDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ExcelSQLProjectDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new ExcelSQLProjectDbContext(options);
        }
    }
}
