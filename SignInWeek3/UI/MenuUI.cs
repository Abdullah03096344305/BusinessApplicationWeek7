using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInWeek3.UI
{
    class MenuUI
    {
        public static int Menu()
        {
            int option;
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("1. SignIn");
            Console.WriteLine();
            Console.WriteLine("2. SignUp");
            Console.WriteLine();
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.WriteLine("Enter Option");            
            if (int.TryParse(Console.ReadLine(), out option))
            {
                return option;
            }
            else
            {
                return -1;
            }           
        }
        public static int Menu1()
        {
            int option1;
            Console.Clear();
            MenuUI.Header();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Are You An Admin or A Customer ? ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1.  Admin");
            Console.WriteLine();
            Console.WriteLine("2.  Customer");          
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out option1))
            {
                return option1;
            }
            else
            {
                return -1;
            }          
        }
        public static int AdminMenu()
        {
            int choice;
            Console.Clear();
            MenuUI.Header();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1.  Add    Product");
            Console.WriteLine();
            Console.WriteLine("2.  Remove Product");
            Console.WriteLine();
            Console.WriteLine("3.  Update Product");
            Console.WriteLine();
            Console.WriteLine("4.  View   Products");
            Console.WriteLine();
            Console.WriteLine("5.  View   Sales");
            Console.WriteLine();
            Console.WriteLine("6.  View   User Data ( Ratings )");
            Console.WriteLine();
            Console.WriteLine("7.  Press 7 to Exit");
            Console.WriteLine();
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                return choice;
            }
            else
            {
                return -1;
            }
        }
        public static int UserMenu()
        {
            Console.Clear();
            MenuUI.Header();
            int opti;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1.     Burgers");
            Console.WriteLine("2.     Exclusive Deals");
            Console.WriteLine("3.     Bill");
            Console.WriteLine("4.     Smash Feed");
            Console.WriteLine("5.     Our Story");
            Console.WriteLine("6.     Contact Us ( Rate Us) ");
            Console.WriteLine("7.     Locations");
            Console.WriteLine("8.     Delivery Charges");
            Console.WriteLine();
            Console.WriteLine("PRESS 8 TO EXIT");            
            if (int.TryParse(Console.ReadLine(), out opti))
            {
                return opti;
            }
            else
            {
                return -1;
            }     
        }      
        public static int SubAdminMenu()
        {
            Console.Clear();
            MenuUI.Header();
            int subChoice;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1.     Burger");
            Console.WriteLine("2.     Deal");
            if (int.TryParse(Console.ReadLine(), out subChoice))
            {
                return subChoice;
            }
            else
            {
                return -1;
            }

        }
        
        public static void Header()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  _________                             ____   ");
            Console.WriteLine(" /   _____/   _____   _____      ______ |  |__");
            Console.WriteLine(" \\_____  \\   /     \\  \\__  \\    /  ___/ |  |  \\");
            Console.WriteLine(" /____    \\ |  Y Y  \\  / __ \\_  \\___ \\  |   Y  \\");
            Console.WriteLine("/_______  / |__|_|  / (____  / /____  > |___|  /");
            Console.WriteLine("        \\/        \\/       \\/       \\/       \\/");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t \t \t \t \t __________");
            Console.WriteLine("\t \t \t \t \t \\______   \\  __ __  _______     ____     ____   _______    ______");
            Console.WriteLine("\t \t \t \t \t  | __ |  _/ |  |  \\ \\_  __ \\   / ___\\  _/ __ \\  \\_  __ \\  /  ___/");
            Console.WriteLine("\t \t \t \t \t  |____|   \\ |  |  /  |  | \\/  / /_/  > \\  ___/   |  | \\/  \\___ \\ ");
            Console.WriteLine("\t \t \t \t \t  |______  / |____/   |__|     \\___  /   \\___  >  |__|    /____  >");
            Console.WriteLine("\t \t \t \t \t         \\/                   /_____/        \\/                \\/");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  _____       __ _  ___                  _      ");
            Console.WriteLine(" / ___/___ _ / /(_)/ _/___   ____ ___   (_)___ _");
            Console.WriteLine("/ /__ / _ `// // // _// _ \\ / __// _ \\ / // _ `/");
            Console.WriteLine("\\___/ \\_,_//_//_//_/  \\___//_/  /_//_//_/ \\_,_/ ");
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
