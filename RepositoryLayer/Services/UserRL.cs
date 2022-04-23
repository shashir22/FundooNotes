using DatabaseLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.FundooNotesContext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        FundooContext fundoo;
        private readonly IConfiguration configuration;
        public UserRL(FundooContext fundoo, IConfiguration configuration)
        {
            this.fundoo = fundoo;
            this.configuration = configuration;
        }
        public void AddUser(UserPostModel user)
        {
            try
            {
                Entity.User user1 = new Entity.User();
                user1.FirstName = user.FirstName;
                user1.LastName = user.LastName;
                user1.Email = user.Email;
                user1.Adress = user.Adress;
                user1.Password = user.Password;
                user1.registerdDate = DateTime.Now;
                fundoo.Users.Add(user1);
                fundoo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}