using ExcelSQLProject.Commands;
using ExcelSQLProject.Models;
using ExcelSQLProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExcelSQLProject.ViewModels
{
    public class DatabaseListingViewModel : ViewModelBase
    {

        private readonly ObservableCollection<UserViewModel> _users;
        public IEnumerable<UserViewModel> Users => _users;
        public ICommand LoadUsersCommand { get; }
        public ICommand ImportExcelCommand { get; }
        



        public DatabaseListingViewModel(UserService userService, NavigationService ImportExcelNavigationService)
        {
            ImportExcelCommand = new NavigateCommand(ImportExcelNavigationService);
            LoadUsersCommand = new LoadUsersCommand(this, userService);
            _users = new ObservableCollection<UserViewModel>();



        }

        public static DatabaseListingViewModel LoadViewModel(UserService userService, NavigationService importExcelNavigationService)
        {
            DatabaseListingViewModel viewModel = new DatabaseListingViewModel(userService, importExcelNavigationService);
            viewModel.LoadUsersCommand.Execute(null);

            return viewModel;
        }

        public void UpdateUsers(IEnumerable<User> users)
        {
            _users.Clear();
            foreach (var user in users)
            {
                //_users.Add(new UserViewModel(user));
                UserViewModel userViewModel = new UserViewModel(user);
                _users.Add(userViewModel);
            }

        }
    }
}
