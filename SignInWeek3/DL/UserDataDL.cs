using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SignInWeek3.BL;
using SignInWeek3.UI;
using System.Threading.Tasks;

namespace SignInWeek3.DL
{
    class UserDataDL
    {
        public static List<UserData> userdata = new List<UserData>();
        public static void ReadUserData()
        {
            string pathUser = @"E:\Week3PDSubmit\SignInWeek3\UserFile.txt";
            if (File.Exists(pathUser))
            {
                using (StreamReader file = new StreamReader(pathUser))
                {
                    string record;
                    while ((record = file.ReadLine()) != null)
                    {
                        string[] fields = record.Split(',');
                        if (fields.Length >= 4)
                        {
                            string name = fields[0];
                            string email = fields[1];
                            string message = fields[2];
                            int rating;
                            if (int.TryParse(fields[3], out rating))
                            {
                                UserData userdatas = new UserData();
                                userdatas.SetName(name);
                                userdatas.SetName(name);
                                userdatas.SetEmail(email);
                                userdatas.SetMessage(message);
                                userdatas.SetRating(rating);
                                userdata.Add(userdatas);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid Rating in record: {record}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid record: {record}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File does not exist: {pathUser}");
            }
        }

        public static void AddUserData(List<UserData> userdata)
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("Enter Your Name:  ");
            string name = Console.ReadLine();            
            Console.WriteLine();
            Console.WriteLine("Enter Your Email:  ");
            string email = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter A Short Message:  ");
            string message = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Rate Us ( A Number Between 1 to 5 ): ");
            int rating = int.Parse(Console.ReadLine());
            UserData userdatas = new UserData();
            userdatas.SetName(name);
            userdatas.SetEmail(email);
            userdatas.SetMessage(message);
            userdatas.SetRating(rating);
            userdata.Add(userdatas);
            using (StreamWriter file = new StreamWriter(@"E:\Week3PDSubmit\SignInWeek3\UserFile.txt", true))
            {
                file.WriteLine("" + name + "," + email + "," + message + "," + rating);
            }
        }

        public static void DisplayUserData(List<UserData> userdata)
        {
            Console.Clear();
            MenuUI.Header();
            for (int i = 0 + 0; i < userdata.Count; i++)
            {
                Console.WriteLine("" + i + 1 + ":    " + userdata[i].GetName() + ", " + userdata[i].GetEmail() + ", " + userdata[i].GetMessage() + ", " + userdata[i].GetRating());
            }
        }

    }
}
