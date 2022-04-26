﻿using DatabaseLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        public void AddUser(UserPostModel user);
        string LoginUser(string email, string password);
        bool ForgetPassword(string email);
        bool ChangePassword(string email, string password, string newpassword);
      
    }
}