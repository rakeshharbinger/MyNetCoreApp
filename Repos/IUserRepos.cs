﻿using MyNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCoreApp.Repos
{
    public interface IUserRepos
    {
        void Register(User user);
        bool IsUserExist(string email);
        User Validate(UserLogin cred);
        IEnumerable<User> GetUserList();
        User GetUser(int id);
        void EditUser(User user);
        void DeleteUser(int id);
    }
}
