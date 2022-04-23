using BusinessLayer.Interfases;
using DatabaseLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Servises
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public void AddUser(UserPostModel user)
        {
            try
            {
                this.userRL.AddUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}