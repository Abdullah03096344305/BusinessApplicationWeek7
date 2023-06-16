using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignInWeek3.BL;
using SignInWeek3.UI;
using System.Threading.Tasks;

namespace SignInWeek3.BL
{
    class UserData
    {
        private string name;
        private string email;
        private string message;
        private int rating;      

        public UserData()
        {          
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }
        public string GetEmail()
        {
            return email;
        }

        public void SetMessage(string message)
        {
            this.message = message;
        }
        public string GetMessage()
        {
            return message;
        }

        public void SetRating(int rating)
        {
            this.rating = rating;
        }
        public int GetRating()
        {
            return rating;
        }

    }
}
