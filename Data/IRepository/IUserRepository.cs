﻿using RunningAppData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.IRepository
{
    public interface IUserRepository
    {

        User GetUserByUsername(string username);
        Task<User> GetUserByUsernameAsync(string username);


    }
}