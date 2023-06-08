﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SignInWeek3.UI;
using System.Threading.Tasks;

namespace SignInWeek3.BL
{
    class MUser
    {
        public string name;
        public string password;
        public string role;
        public static List<MUser> users = new List<MUser>();
        public MUser(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public MUser(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        public bool isAdmin()
        {
            if (role == "Admin")
            {
                return true;
            }
            return false;
        }
    }
    
    
    
}
