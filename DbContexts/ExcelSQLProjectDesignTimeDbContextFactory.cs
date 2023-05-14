using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSQLProject.DbContexts
{
    public class ExcelSQLProjectDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ExcelSQLProjectDbContext>
    {
        public ExcelSQLProjectDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=ExcelSQLProject.db").Options;
            return new ExcelSQLProjectDbContext(options);
        }
    }
}
