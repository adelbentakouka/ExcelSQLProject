using ExcelSQLProject.DbContexts;
using ExcelSQLProject.Models;
using ExcelSQLProject.Services.UserCreators;
using ExcelSQLProject.Services.UserProviders;
using ExcelSQLProject.Stores;
using ExcelSQLProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;


namespace ExcelSQLProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private const string CONNECTION_STRING = "Data Source=ExcelSQLProject.db";
        private readonly UserService _userService;
        private readonly NavigationStore _navigationStore;
        private readonly ExcelSQLProjectDbContextFactory _excelSQLProjectDbContextFactory;

        public App()
        {
            _excelSQLProjectDbContextFactory = new ExcelSQLProjectDbContextFactory(CONNECTION_STRING);
            IUserProvider userProvider = new DatabaseUserProvider(_excelSQLProjectDbContextFactory);
            IUserCreator userCreator = new DatabaseUserCreator(_excelSQLProjectDbContextFactory);
            _userService = new UserService(userProvider,userCreator);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            using (ExcelSQLProjectDbContext dbContext = _excelSQLProjectDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

                


            _navigationStore.CurrentViewModel = CreateImportExcelToDatabaseViewmodel();

            

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();


       

            base.OnStartup(e);


        }

        private ImportExcelToDatabaseViewModel CreateImportExcelToDatabaseViewmodel()
        {
            return new ImportExcelToDatabaseViewModel(_userService,new Services.NavigationService( _navigationStore, CreateUserViewModel));
        }

        private DatabaseListingViewModel CreateUserViewModel()
        {
            return DatabaseListingViewModel.LoadViewModel(_userService,new Services.NavigationService(_navigationStore, CreateImportExcelToDatabaseViewmodel));
        }
    }
}
