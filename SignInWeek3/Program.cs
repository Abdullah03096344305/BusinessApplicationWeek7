using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SignInWeek3.BL;
using SignInWeek3.UI;
using System.Threading.Tasks;

namespace SignInWeek3
{
    class Program
    {
        static void Main(string[] args)
        {
          
            string path = "E:\\SecondSemester\\SignInWeek3\\textfile.txt";           
            Burger info = new Burger(0);            
            string path1 = @"E:\SecondSemester\ClassPracticeWeek3\BurgerFile.txt";
            string pathUser = @"E:\SecondSemester\SignInWeek3\UserFile.txt";
            List<Burger> burgers = new List<Burger>();
            ReadBurgerData(path1, burgers);
            ReadUserData(pathUser, UserData.userdata);
                     
            
            int option;
            int option1;
            int option2;
            int choice;

            string adminname = "Abdul";
            string adminpass = "0";
            string adminUserCheck;
            string adminPassCheck;
            bool check = ReadData(path, MUser.users);         
            do
            {
                option1 = MenuUI.Menu1();
                Console.Clear();
                if( option1 == 1)
                {  
                    Console.Clear();
                    MenuUI.Header();
                    Console.WriteLine("Enter Admin Username");
                    adminUserCheck = Console.ReadLine();
                    Console.WriteLine("Enter Admin Password");
                    adminPassCheck = Console.ReadLine();
                    if (adminUserCheck == adminname && adminPassCheck == adminpass)
                    {
                        do
                        {
                            choice = MenuUI.AdminMenu();
                            if (choice == 1)
                            {
                                AddProduct(burgers);
                            }
                            else if (choice == 2)
                            {
                                DeleteProduct( burgers, path1);
                            }
                            else if (choice == 3)
                            {
                                UpdateProduct( burgers);
                            }
                            else if (choice == 4)
                            {
                                DisplayBurgers(burgers);
                            }
                            else if (choice == 5)
                            {
                                Console.Clear();
                                MenuUI.Header();
                                Console.WriteLine();
                                Console.WriteLine("Sales");
                                Console.WriteLine("Total sale is : " + info.burgertotal);
                            }
                            else if (choice == 6)
                            {
                                Console.WriteLine("Ratings");
                                DisplayUserData(UserData.userdata);
                            }
                            Console.ReadKey();
                        }
                        while (choice < 7);

                    }
                        Console.ReadKey();
                }
                else if ( option1 == 2)
                {
                    do
                    {
                        Console.Clear();
                        option = MenuUI.Menu();
                        if (option == 1)
                        {
                            MUser user = TakeInputWithoutRole();
                            if (user != null)
                            {
                                user = SignIn(user, MUser.users);
                                if (user == null)
                                    Console.WriteLine("Invalid User");
                                else if (user.isAdmin())
                                {
                                    do
                                    {
                                        Console.WriteLine("Admin (User) Menu");
                                        option2 = MenuUI.UserMenu();
                                        if (option2 == 1)
                                        {
                                            MenuUI.Header();
                                            DisplayBurgers(burgers);
                                            info.burgertotal = CalculateBurgerPrice(burgers, info);
                                            Console.WriteLine("Burger Total Price: " + info.burgertotal);
                                            Console.WriteLine("Press Any Key to Continue! ");
                                            Console.ReadKey();
                                        }                                          
                                        else if (option2 == 2)
                                        {
                                            Bill(info);
                                        }
                                        else if (option2 == 3)
                                        {
                                            BurgerUI.SmashFeed();
                                        }
                                        else if (option2 == 4)
                                        {
                                            BurgerUI.OurStory();
                                        }
                                        else if (option2 == 5)
                                        {
                                            AddUserData(UserData.userdata);
                                        }
                                        else if (option2 == 6)
                                        {
                                            BurgerUI.Locations();
                                        }
                                        else if (option2 == 7)
                                        {
                                            Delivery(info);
                                        }
                                        Console.ReadKey();
                                    }
                                    while (option2 < 8);


                                }
                            }
                        }
                        else if (option == 2)
                        {
                            MUser user = TakeInputWithRole();
                            if (user != null)
                            {
                                StoreDataInFile(path, user);
                                StoreDataInList(MUser.users, user);

                            }
                        }
                        else if(option == 3)
                        {
                            break;
                        }                        
                       /* Console.ReadKey();*/
                    }
                    while (option < 4);
                }
               
            }
            while (option1 < 3);
        
        }
        
        static void Bill(Burger info)
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            int finalTotal = info.burgertotal ;
            if (finalTotal < 1)
            {
                Console.WriteLine("Please Purchase Something First!");
            }
            if (finalTotal > 1)
            {
                Console.WriteLine("Thanks For Ordering From Us! ");
                Console.WriteLine();
                Console.WriteLine("Your Total Bill Is  " + finalTotal);
            }
            Console.WriteLine("Press any Key to Conitnue ...");
        }
        
        
        static void Delivery(Burger info)
        {
            int deliverytotal = info.burgertotal ;
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("              ***** DELIVERY CHARGES *****");
            if (deliverytotal > 3000)
            {
                Console.WriteLine("                                 As Your Bill Amount Is Greater Than 3000 There is No Delivery Charges ");
                Console.WriteLine();
                Console.WriteLine("                                              Thanks For Purchasing ");
            }
            else if (deliverytotal == 3000)
            {
                Console.WriteLine("                                 As Your Bill Amount Is 3000 There is No Delivery Charges ");
                Console.WriteLine();
                Console.WriteLine("                                              Thanks For Purchasing ");
            }
            else if (deliverytotal >= 2000 && deliverytotal < 3000)
            {
                Console.WriteLine("                                    Delivery Charges are 250");
                Console.WriteLine();
                Console.WriteLine("                                              Thanks For Purchasing ");
            }
            else if (deliverytotal > 1 && deliverytotal < 2000)
            {
                Console.WriteLine("                                    Delivery Charges are 350");
                Console.WriteLine();
                Console.WriteLine("                                              Thanks For Purchasing ");
            }
            else if (deliverytotal < 1)
            {
                Console.WriteLine();
                Console.WriteLine("NO DELIVERY CHARGES");
                Console.WriteLine();
                Console.WriteLine("Please Purchase Something First ");
            }
            Console.WriteLine("Press any Key to Conitnue ...");
        }
       


        static string ParseData(string record, int field)
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
                    item = item + record[x];
                }
            }
            return item;
        }
        static bool ReadData(string path, List<MUser> users)

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
        static MUser TakeInputWithoutRole()
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
        static MUser TakeInputWithRole()
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
        static void StoreDataInList(List<MUser> users, MUser user)
        {
            users.Add(user);
        }
        static void StoreDataInFile(string path, MUser user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.name + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }
        static MUser SignIn(MUser user, List<MUser> users)
        {
            foreach (MUser storedUser in users)
            {
                if (user.name == storedUser.name && user.password == storedUser.password)
                {
                    return storedUser;
                }
            }
            return null;
        }
        static void DeleteProduct(List<Burger> burgers, string path1)
        {
            Console.Clear();
            Console.WriteLine("Current list of burgers:");
            DisplayBurgers(burgers);
            Console.Write("Enter the index of the burger to delete: ");
            int indexToDelete;
            if (int.TryParse(Console.ReadLine(), out indexToDelete))
            {
                if (indexToDelete >= 0 && indexToDelete < burgers.Count)
                {
                    burgers.RemoveAt(indexToDelete);
                    Console.WriteLine("Burger deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid index. No burger deleted.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. No burger deleted.");
            }
            WriteBurgersToFile(burgers, path1);
            Console.WriteLine("Updated list of burgers:");
            DisplayBurgers(burgers);
        }

        static void ReadBurgerData(string path1, List<Burger> burgers)
        {
            if (File.Exists(path1))
            {
                using (StreamReader file = new StreamReader(path1))
                {
                    string record;
                    while ((record = file.ReadLine()) != null)
                    {
                        string[] fields = record.Split(',');
                        if (fields.Length >= 2)
                        {
                            string name = fields[0];
                            int price;
                            if (int.TryParse(fields[1], out price))
                            {
                                Burger burger = new Burger(name, price);
                                burgers.Add(burger);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid price in record: {record}");
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
                Console.WriteLine($"File does not exist: {path1}");
            }
        }
        static void ReadUserData(string pathUser, List<UserData> userdata)
        {
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
                                UserData userdatas = new UserData(name, email, message, rating);
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


        static void AddProduct(List<Burger> burgers)
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("Enter Burger Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Burger Price: ");
            int price = int.Parse(Console.ReadLine());
            Burger burger = new Burger(name, price);
            burgers.Add(burger);
            using (StreamWriter file = new StreamWriter(@"E:\SecondSemester\ClassPracticeWeek3\BurgerFile.txt", true))
            {
                file.WriteLine($"{name},{price}");
            }
        }
        static void AddUserData(List<UserData> userdata)
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
            UserData userdatas = new UserData(name, email,message,rating);
            userdata.Add(userdatas);
            using (StreamWriter file = new StreamWriter(@"E:\SecondSemester\SignInWeek3\UserFile.txt", true))
            {
                file.WriteLine("" + name + "," + email + "," + message + "," + rating);
            }
        }
        static void DisplayBurgers(List<Burger> burgers)
        {
            for (int i = 0 + 0; i < burgers.Count; i = i + 1)
            {
                Console.WriteLine("" + (i + 1) + ":    " + burgers[i].name + ", " + burgers[i].price);
            }
        }
        static void DisplayUserData(List<UserData> userdata)
        {
            Console.Clear();
            MenuUI.Header();
            for (int i = 0 + 0; i < userdata.Count; i = i + 1)
            {
                Console.WriteLine("" + i + 1 + ":    " + userdata[i].Name + ", " + userdata[i].Email + ", " + userdata[i].Message + ", " + userdata[i].Rating);
            }
        }

        static int CalculateBurgerPrice(List<Burger> burgers, Burger info)
        {
            int burgerchoice;
            int burgerquantity;
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter Your Choice: ");
                burgerchoice = Convert.ToInt32(Console.ReadLine());
                if (burgerchoice == 0)
                {
                    break;
                }
                Console.Write("Enter Burger Quantity: ");
                burgerquantity = Convert.ToInt32(Console.ReadLine());
                if (burgerchoice > 0 && burgerchoice <= burgers.Count)
                {
                    Burger selectedBurger = burgers[burgerchoice - 1];
                    info.burgertotal += burgerquantity * selectedBurger.price;
                }
                else
                {
                    Console.WriteLine("Invalid burger choice. Please try again.");
                }
            }
            return info.burgertotal;
        }

        static void UpdateProduct(List<Burger> burgers)
        {
            Console.Clear();
            for (int i = 0; i < burgers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {burgers[i].name}: ${burgers[i].price}");
            }
            Console.WriteLine("Enter the index of the product to update (1 to " + burgers.Count + "):");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            if (index >= 0 && index < burgers.Count)
            {
                Console.WriteLine("Enter the updated price for " + burgers[index].name + ":");
                int updatedPrice = Convert.ToInt32(Console.ReadLine());
                burgers[index].price = updatedPrice;
                Console.WriteLine("Price updated successfully.");
                UpdateTextFile(burgers);
            }
            else
            {
                Console.WriteLine("Invalid index. No update performed.");
            }
        }

        static void UpdateTextFile(List<Burger> burgers)
        {
            string path1 = @"E:\SecondSemester\ClassPracticeWeek3\BurgerFile.txt";
            List<string> lines = new List<string>();
            foreach (Burger burger in burgers)
            {
                lines.Add($"{burger.name},{burger.price}");
            }
            File.WriteAllLines(path1, lines);
            Console.WriteLine("Text file updated successfully.");
        }
        static void WriteBurgersToFile(List<Burger> burgers, string path1)
        {
            using (StreamWriter writer = new StreamWriter(path1))
            {
                foreach (Burger burger in burgers)
                {
                    writer.WriteLine($"{burger.name},{burger.price}");
                }
            }
        }
        

    }
}
