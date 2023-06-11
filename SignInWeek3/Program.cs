﻿using System;
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
          
            string path = @"E:\Week3PDSubmit\SignInWeek3\textfile.txt";
            Burger info = new Burger(0);
            string path1 = @"E:\Week3PDSubmit\SignInWeek3\BurgerFile.txt";
            string pathUser = @"E:\Week3PDSubmit\SignInWeek3\UserFile.txt";

            BurgerDL.ReadBurgerData(path1, BurgerDL.burgers);
            UserDataDL.ReadUserData(pathUser, UserDataDL.userdata);

           
            int option;
            int option1;
            int option2;
            int choice;

            string adminname = "Abdul";
            string adminpass = "0";
            string adminUserCheck;
            string adminPassCheck;
            bool check = MUserDL.ReadData(path, MUser.users);         
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
                                BurgerDL.AddProduct(BurgerDL.burgers);
                            }
                            else if (choice == 2)
                            {
                                BurgerDL.DeleteProduct(BurgerDL.burgers, path1);
                            }
                            else if (choice == 3)
                            {
                                BurgerDL.UpdateProduct(BurgerDL.burgers);
                            }
                            else if (choice == 4)
                            {
                                BurgerDL.DisplayBurgers(BurgerDL.burgers);
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
                                UserDataDL.DisplayUserData(UserDataDL.userdata);
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
                            MUser user = MUserDL.TakeInputWithoutRole();
                            if (user != null)
                            {
                                user = MUserDL.SignIn(user, MUser.users);
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
                                            BurgerDL.DisplayBurgers(BurgerDL.burgers);
                                            info.burgertotal = BurgerDL.CalculateBurgerPrice(BurgerDL.burgers, info);
                                            Console.WriteLine("Burger Total Price: " + info.burgertotal);
                                            Console.WriteLine("Press Any Key to Continue! ");
                                            Console.ReadKey();
                                        }                                          
                                        else if (option2 == 2)
                                        {
                                            BurgerUI.Bill(info);
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
                                            UserDataDL.AddUserData(UserDataDL.userdata);
                                        }
                                        else if (option2 == 6)
                                        {
                                            BurgerUI.Locations();
                                        }
                                        else if (option2 == 7)
                                        {
                                            BurgerUI.Delivery(info);
                                        }
                                        Console.ReadKey();
                                    }
                                    while (option2 < 8);


                                }
                            }
                        }
                        else if (option == 2)
                        {
                            MUser user = MUserDL.TakeInputWithRole();
                            if (user != null)
                            {
                                MUserDL.StoreDataInFile(path, user);
                                MUserDL.StoreDataInList(MUser.users, user);

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
       
       
       
        

    }
}
