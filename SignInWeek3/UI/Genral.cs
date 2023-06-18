using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInWeek3.UI
{
    class Genral
    {
        public static int GetChoice()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Enter your choice: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                return -1;
            }
            else
            {
                return choice;
            }
        }
        public static int GetInt(string message)
        {
            int result;
            while (true)
            {
                if (int.TryParse(GetInput(message), out result))
                {
                    return result;
                }
                else
                {
                    InvalidInputError();
                }
            }
        }
        public static string GetInput(string message)
        {
            string input;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Enter {0}: ", message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            input = Console.ReadLine();
            return input;
        }
        public static void Halt()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("press Enter key to continue...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }
        public static void InvalidInputError()
        {
            DisplayError("Invalid Input");
        }
        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Error:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
            Halt();
        }
    }
}
