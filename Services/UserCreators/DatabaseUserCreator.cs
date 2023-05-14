using ExcelSQLProject.DbContexts;
using ExcelSQLProject.DTOs;
using ExcelSQLProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSQLProject.Services.UserCreators
{
    public class DatabaseUserCreator : IUserCreator
    {
        private readonly ExcelSQLProjectDbContextFactory _dbContextFactory;

        public DatabaseUserCreator(ExcelSQLProjectDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateUser(User user)
        {
            using (ExcelSQLProjectDbContext context = _dbContextFactory.CreateDbContext())
            {
                UserDTO userDTO = ToUserDTO(user);

                context.Users.Add(userDTO);
                await context.SaveChangesAsync();
            }

            
        }



        private UserDTO ToUserDTO(User user)
        {
            return new UserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
            };
        }
    }
}
