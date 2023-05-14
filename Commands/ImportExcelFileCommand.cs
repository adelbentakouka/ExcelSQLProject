using ExcelSQLProject.Models;
using ExcelSQLProject.Services;
using ExcelSQLProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSQLProject.Commands
{
    public class ImportExcelFileCommand : AsyncCommandBase
    {
        private readonly ImportExcelToDatabaseViewModel _importExcelToDatabaseView;
        private readonly UserService _userService;
        private readonly NavigationService _userViewNavigationService;

        public ImportExcelFileCommand(ViewModels.ImportExcelToDatabaseViewModel importExcelToDatabaseView, UserService userService,NavigationService userViewNavigationService)
        {

            _importExcelToDatabaseView = importExcelToDatabaseView;
            _userService= userService;
            _userViewNavigationService = userViewNavigationService;
            _importExcelToDatabaseView.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ImportExcelToDatabaseViewModel.Path))
            {
                OnCanExecutedChanged();
            }
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            await Task.Run(() =>  _userService.ImportUserFromExcel(_importExcelToDatabaseView.Path));
            _userViewNavigationService.Navigate();

        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_importExcelToDatabaseView.Path) && File.Exists(_importExcelToDatabaseView.Path) && !(Path.GetExtension(_importExcelToDatabaseView.Path) == "xlsx" || Path.GetExtension(_importExcelToDatabaseView.Path) == "csv") && base.CanExecute(parameter);
        }
    }
}
