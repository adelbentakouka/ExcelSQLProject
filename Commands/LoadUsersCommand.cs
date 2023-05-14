using ExcelSQLProject.Models;
using ExcelSQLProject.ViewModels;
using ExcelSQLProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExcelSQLProject.Commands
{
    public class LoadUsersCommand : AsyncCommandBase
    {
        private readonly DatabaseListingViewModel _viewModel;
        private readonly UserService _userService;

        public LoadUsersCommand(DatabaseListingViewModel viewModel, UserService userService)
        {
            _viewModel = viewModel;
            _userService = userService;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                IEnumerable<User> users = await _userService.GetUsers();

                _viewModel.UpdateUsers(users);
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error");
            }
            
        }
    }
}
