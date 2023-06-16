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
    class MUserDL
    {
        public static List<MUser> users = new List<MUser>();
        public static string ParseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length;
            x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item += record[x];
                }
            }
            return item;
        }
        public static bool ReadData(string path, List<MUser> users)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string name = ParseData(record, 1);
                    string password = ParseData(record, 2);
                    string role = ParseData(record, 3);
                    MUser user = new MUser(name, password, role);
                    StoreDataInList(users, user);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        public static MUser TakeInputWithoutRole()
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                MUser user = new MUser(name, password);
                return user;
            }
            return null;

        }
        public static MUser TakeInputWithRole()
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("Enter Name: ");
            Console.WriteLine();
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            Console.WriteLine();
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role: ");
            Console.WriteLine();
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                MUser user = new MUser(name, password, role);
                return user;
            }
            return null;
        }
        public static void StoreDataInList(List<MUser> users, MUser user)
        {
            users.Add(user);
        }
        public static void StoreDataInFile(string path, MUser user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.GetName() + "," + user.GetPassword() + "," + user.GetRole());
            file.Flush();
            file.Close();
        }
        public static MUser SignIn(MUser user, List<MUser> users)
        {
            foreach (MUser storedUser in users)
            {
                if (user.GetName() == storedUser.GetName() && user.GetPassword() == storedUser.GetPassword())
                {
                    return storedUser;
                }
            }
            return null;
        }
    }
}
