using ExcelSQLProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSQLProject.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly User _user;

        public string FirstName => _user.FirstName;
        public string LastName => _user.LastName;
        public int Age => _user.Age;
        public string PhoneNumber => _user.PhoneNumber;
        public string Email => _user.Email;

        public UserViewModel(User user)
        {

            _user = user;

        }
    }
}
