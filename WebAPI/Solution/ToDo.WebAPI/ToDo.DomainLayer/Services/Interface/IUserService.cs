﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebAPI.EF.Data.Model;

namespace ToDo.DomainLayer.Services.Interface
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Register(User user);

        string ForgotPassword(User user);
        Task<int> GetUserID(string userName);
    }
}
