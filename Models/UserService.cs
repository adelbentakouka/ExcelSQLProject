using ExcelSQLProject.Services.UserCreators;
using ExcelSQLProject.Services.UserProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelSQLProject.Models
{
    public class UserService
    {
        private readonly IUserProvider _userProvider;
        private readonly IUserCreator _userCreator;
        //private readonly List<User> _users;

        public UserService(IUserProvider userProvider, IUserCreator userCreator)
        {
            _userProvider = userProvider;
            _userCreator = userCreator;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userProvider.GetAllUsers();
        }


        public async Task AddUser(User user)
        {
            await _userCreator.CreateUser(user);
            
        }

        public async Task ImportUserFromExcel(String path)
        {
            if (path == null) { return; }
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            List<List<String>> usersExcel = new List<List<String>>();


            for (int i = 2; i <= rowCount; i++)
            {
                List<String> userExcel = new List<String>();


                if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                    userExcel.Add(xlRange.Cells[i, 1].Value2.ToString());
                else break;
                if (xlRange.Cells[i, 2] != null && xlRange.Cells[i, 1].Value2 != null)
                    userExcel.Add(xlRange.Cells[i, 2].Value2.ToString());
                else break;
                if (xlRange.Cells[i, 3] != null && xlRange.Cells[i, 1].Value2 != null)
                    userExcel.Add(xlRange.Cells[i, 3].Value2.ToString());
                else break;
                if (xlRange.Cells[i, 4] != null && xlRange.Cells[i, 1].Value2 != null)
                    userExcel.Add(xlRange.Cells[i, 4].Value2.ToString());
                else break;
                if (xlRange.Cells[i, 5] != null && xlRange.Cells[i, 1].Value2 != null)
                    userExcel.Add(xlRange.Cells[i, 5].Value2.ToString());
                else break;



                usersExcel.Add(userExcel);


                /*for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                }*/
            }

            foreach (List<String> user in usersExcel)
            {
                await AddUser(new User(user[0], user[1], int.Parse(user[2]), user[3], user[4]));
            }


            /*string ExcelCase = xlRange.Cells[1, 1].Value2.ToString();


            Trace.WriteLine(ExcelCase);
            */


            //close and release
            xlWorkbook.Close();
            //quit and release
            xlApp.Quit();

        }
    }
}
