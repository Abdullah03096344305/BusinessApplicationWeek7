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
    class BurgerDL
    {
        public static List<Burger> burgers = new List<Burger>();
        public static void ReadBurgerData()
        {
            string path = @"E:\Week3PDSubmit\SignInWeek3\BurgerFile.txt";
            if (File.Exists(path))
            {
                using (StreamReader file = new StreamReader(path))
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
                                Console.WriteLine("Invalid price in record: " + record);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid record: " + record);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File does not exist: {path}");
            }
        }

        public static void UpdateProduct()
        {
            Console.Clear();          
            BurgerUI.DisplayBurgers();
            Console.WriteLine("Enter the index of the product to update (1 to " + burgers.Count + "):");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            if (index >= 0 && index < burgers.Count)
            {
                Console.WriteLine("Enter the updated price for " + burgers[index].GetName() + ":");
                int updatedPrice = Convert.ToInt32(Console.ReadLine());
                burgers[index].SetPrice(updatedPrice) ;
                Console.WriteLine("Price updated successfully.");
                UpdateTextFile();
            }
            else
            {
                Console.WriteLine("Invalid index. No update performed.");
            }
        }

        public static void UpdateTextFile()
        {
            string path = @"E:\Week3PDSubmit\SignInWeek3\BurgerFile.txt";
            List<string> lines = new List<string>();
            foreach (Burger burger in burgers)
            {
                lines.Add($"{burger.GetName()},{burger.GetPrice()}");
            }
            File.WriteAllLines(path, lines);
            Console.WriteLine("Text file updated successfully.");
        }

        public static void WriteBurgersToFile()
        {
            string path = @"E:\Week3PDSubmit\SignInWeek3\BurgerFile.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Burger burger in burgers)
                {
                    writer.WriteLine($"{burger.GetName()},{burger.GetPrice()}");
                }
            }
        }


        public static int CalculateBurgerPrice(int burgerTotal)
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
                    burgerTotal += burgerquantity * selectedBurger.GetPrice();
                }
                else
                {
                    Console.WriteLine("Invalid burger choice. Please try again.");
                }
            }
            return burgerTotal;
        }

        public static void AddProduct()
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("Enter Burger Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Burger Price: ");
            int price = 0;
            bool isValidPrice = false;
            while (!isValidPrice)
            {
                string priceInput = Console.ReadLine();
                isValidPrice = int.TryParse(priceInput, out price) && price >= 0;
                if (!isValidPrice)
                {
                    Console.WriteLine("Invalid price. Please enter a valid non-negative integer value.");
                }
            }
            if (!string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                Burger burger = new Burger(name, price);
                burgers.Add(burger);

                using (StreamWriter file = new StreamWriter(@"E:\Week3PDSubmit\SignInWeek3\BurgerFile.txt", true))
                {
                    file.WriteLine($"{name},{price}");
                }
            }
            else
            {
                Console.WriteLine("Invalid name. Please enter a valid name consisting of letters, digits, or spaces only.");
            }
        }

        public static void DeleteProduct( )
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("Current list of burgers:");
            BurgerUI.DisplayBurgers();
            Console.Write("Enter the index of the burger to delete: ");
            int indexToDelete;
            if (int.TryParse(Console.ReadLine(), out indexToDelete))
            {
                if (indexToDelete >= 0 && indexToDelete < burgers.Count)
                {
                    burgers.RemoveAt(indexToDelete - 1);
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
            WriteBurgersToFile();
            Console.WriteLine("Updated list of burgers:");
            BurgerUI.DisplayBurgers();
        }





    }
}