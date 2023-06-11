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
            option = int.Parse(Console.ReadLine());
            return option;
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
            option1 = int.Parse(Console.ReadLine());
            Console.ResetColor();
            return option1;
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
            Console.ResetColor();
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static int UserMenu()
        {
            Console.Clear();
            MenuUI.Header();
            int opti;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1.     Burgers");
            Console.WriteLine("2.     Bill");
            Console.WriteLine("3.     Smash Feed");
            Console.WriteLine("4.     Our Story");
            Console.WriteLine("5.     Contact Us ( Rate Us) ");
            Console.WriteLine("6.     Locations");
            Console.WriteLine("7.     Delivery Charges");
            Console.WriteLine();
            Console.WriteLine("PRESS 8 TO EXIT");
            opti = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Press Any Key To Continue...");
            return opti;
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
