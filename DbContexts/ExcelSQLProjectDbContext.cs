using ExcelSQLProject.DTOs;
using ExcelSQLProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSQLProject.DbContexts
{
    public class ExcelSQLProjectDbContext : DbContext
    {
        public ExcelSQLProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserDTO> Users { get; set; }
    }
}
