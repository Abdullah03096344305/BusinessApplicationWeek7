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
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }

        public static List<UserData> userdata = new List<UserData>();

        public UserData(string name, string email, string message, int rating)
        {
            Name = name;
            Email = email;
            Message = message;
            Rating = rating;
        }

    }
}
