﻿using ExcelSQLProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSQLProject.Services.UserCreators
{
    public interface IUserCreator
    {
        Task CreateUser(User user);
    }
}
