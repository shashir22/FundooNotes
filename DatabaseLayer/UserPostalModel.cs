﻿using System;

namespace DatabaseLayer
{
    public class UserPostModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime registerdDate { get; set; }
    }
}