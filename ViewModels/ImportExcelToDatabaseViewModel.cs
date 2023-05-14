using ExcelSQLProject.Commands;
using ExcelSQLProject.Models;
using ExcelSQLProject.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExcelSQLProject.ViewModels
{
    public class ImportExcelToDatabaseViewModel : ViewModelBase
    {
        private string _path;
        private UserService _userService;
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        public ICommand ImportExcelFileCommand { get; }
        public ICommand ShowDBCommand { get; }

        public ImportExcelToDatabaseViewModel(UserService userService, Services.NavigationService userViewNavigationService)
        {
            _userService = userService;
            ImportExcelFileCommand = new ImportExcelFileCommand(this,userService, userViewNavigationService);
            ShowDBCommand = new NavigateCommand(userViewNavigationService);
        }
    }
}
