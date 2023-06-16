using System;
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
        private string name;
        private string password;
        private string role;        
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
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string GetPassword()
        {
            return password;
        }
        public void SetRole(string role)
        {
            this.role = role;
        }
        public string GetRole()
        {
            return role;
        }

        public bool IsAdmin()
        {
            if (role == "Admin")
            {
                return true;
            }
            return false;
        }
    }
    
    
    
}
