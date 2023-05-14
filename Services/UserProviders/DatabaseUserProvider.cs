using ExcelSQLProject.DbContexts;
using ExcelSQLProject.DTOs;
using ExcelSQLProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSQLProject.Services.UserProviders
{
    public class DatabaseUserProvider : IUserProvider
    {

        private readonly ExcelSQLProjectDbContextFactory _dbContextFactory;

        public DatabaseUserProvider(ExcelSQLProjectDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (ExcelSQLProjectDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<UserDTO> userDTOs = await context.Users.ToListAsync();

                return (IEnumerable<User>)userDTOs.Select(u => ToUser(u));
            }
        }

        private static User ToUser(UserDTO dto)
        {
            return new User(dto.FirstName, dto.LastName, dto.Age, dto.PhoneNumber, dto.Email);
        }
    }
}
