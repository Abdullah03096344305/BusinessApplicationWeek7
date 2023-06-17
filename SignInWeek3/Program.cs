using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SignInWeek3.BL;
using SignInWeek3.UI;
using SignInWeek3.DL;
using System.Threading.Tasks;

namespace SignInWeek3
{
    class Program
    {
        static void Main(string[] args)
        {
            int burgerTotal = 0;
            int dealTotal = 0;
            string path = @"E:\Week3PDSubmit\SignInWeek3\textfile.txt";
            string dealpath = @"E:\Week3PDSubmit\SignInWeek3\DealFile.txt";
            string path1 = @"E:\Week3PDSubmit\SignInWeek3\BurgerFile.txt";
            string pathUser = @"E:\Week3PDSubmit\SignInWeek3\UserFile.txt";
            BurgerDL.ReadBurgerData( BurgerDL.burgers);
            DealsDL.ReadDealData( DealsDL.deals);
            UserDataDL.ReadUserData(pathUser, UserDataDL.userdata);
            int option;
            int option1;
            int option2;
            int choice;
            int subChoice;
            string adminname = "Abdul";
            string adminpass = "0";
            string adminUserCheck;
            string adminPassCheck;
            bool check = MUserDL.ReadData(path, MUserDL.users);
            do
            {
                option1 = MenuUI.Menu1();
                Console.Clear();
                if (option1 == 1)
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
                            
                            if(choice != -1)
                            {
                            if (choice == 1)
                            {
                               subChoice = MenuUI.SubAdminMenu();
                               if(subChoice == 1)
                               {
                                    BurgerDL.AddProduct(BurgerDL.burgers);
                               }
                               else if(subChoice == 2)
                               {
                                    DealsDL.AddDealProduct(DealsDL.deals);
                               }                                
                            }
                            else if (choice == 2)
                            {
                                    subChoice = MenuUI.SubAdminMenu();
                                    if (subChoice == 1)
                                    {
                                        BurgerDL.DeleteProduct(BurgerDL.burgers, path1);
                                    }
                                    else if (subChoice == 2)
                                    {
                                        DealsDL.DeleteDealProduct(DealsDL.deals, dealpath);
                                    }                                   
                            }
                            else if (choice == 3)
                            {
                                    subChoice = MenuUI.SubAdminMenu();
                                    if (subChoice == 1)
                                    {
                                        BurgerDL.UpdateProduct(BurgerDL.burgers);
                                    }
                                    else if (subChoice == 2)
                                    {
                                        DealsDL.UpdateDeal(DealsDL.deals);
                                    }                                   
                            }
                            else if (choice == 4)
                            {
                                    subChoice = MenuUI.SubAdminMenu();
                                    if (subChoice == 1)
                                    {
                                        BurgerUI.DisplayBurgers();
                                    }
                                    else if (subChoice == 2)
                                    {
                                        DealsUI.DisplayDeals();
                                    }                                   
                            }
                            else if (choice == 5)
                            {                               
                                BurgerUI.TotalSales(burgerTotal,dealTotal);
                            }
                            else if (choice == 6)
                            {
                                Console.WriteLine("Ratings");
                                UserDataDL.DisplayUserData(UserDataDL.userdata);
                            }
                            else if (choice == 7)
                            {
                                break;
                            }
                                Console.WriteLine("Press Any Key to Continue...");
                                Console.ReadKey();
                            }
                        }
                        while (choice < 7);

                    }
                    Console.ReadKey();
                }
                else if (option1 == 2)
                {
                    do
                    {
                        Console.Clear();
                        option = MenuUI.Menu();
                        if (option == 1)
                        {
                            MUser user = MUserDL.TakeInputWithoutRole();
                            if (user != null)
                            {
                                user = MUserDL.SignIn(user, MUserDL.users);
                                if (user == null)
                                    Console.WriteLine("Invalid User");
                                else if (user.IsAdmin())
                                {
                                    do
                                    {
                                        Console.WriteLine("Admin (User) Menu");
                                        option2 = MenuUI.UserMenu();
                                        if (option2 == 1)
                                        {
                                            MenuUI.Header();
                                            BurgerUI.DisplayBurgers();                                         
                                            burgerTotal = BurgerDL.CalculateBurgerPrice(BurgerDL.burgers,burgerTotal);
                                            Console.WriteLine("Burger Total Price: " + burgerTotal);
                                            Console.WriteLine("Press Any Key to Continue! ");                                        
                                        }
                                        else if (option2 == 2)
                                        {
                                            MenuUI.Header();
                                            DealsUI.DisplayDeals();
                                            dealTotal = DealsDL.CalculateDealPrice(DealsDL.deals, dealTotal);
                                            Console.WriteLine("Deals Total Price: " + dealTotal);
                                            Console.WriteLine("Press Any Key to Continue! ");
                                        }
                                        else if (option2 == 3)
                                        {
                                            BurgerUI.Bill(burgerTotal,dealTotal);
                                        }
                                        else if (option2 == 4)
                                        {
                                            BurgerUI.SmashFeed();
                                        }
                                        else if (option2 == 5)
                                        {
                                            BurgerUI.OurStory();
                                        }
                                        else if (option2 == 6)
                                        {
                                            UserDataDL.AddUserData(UserDataDL.userdata);
                                        }
                                        else if (option2 == 7)
                                        {
                                            BurgerUI.Locations();
                                        }
                                        else if (option2 == 8)
                                        {
                                            BurgerUI.Delivery(burgerTotal,dealTotal);
                                        }                                        
                                        Console.ReadKey();
                                    }
                                    while (option2 < 9 && option2 > 0 );


                                }
                            }
                        }
                        else if (option == 2)
                        {
                            MUser user = MUserDL.TakeInputWithRole();
                            if (user != null)
                            {
                                MUserDL.StoreDataInFile(path, user);
                                MUserDL.StoreDataInList(MUserDL.users, user);

                            }
                        }
                        else if (option == 3)
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





    }
}
