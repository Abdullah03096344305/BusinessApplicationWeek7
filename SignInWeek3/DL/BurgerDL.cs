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
        public int burgertotal;
        public static List<Burger> burgers = new List<Burger>();
        public static void ReadBurgerData(string path1, List<Burger> burgers)
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
        public static void UpdateProduct(List<Burger> burgers)
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
            string path1 = @"E:\Week3PDSubmit\SignInWeek3\BurgerFile.txt";
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
        public static int CalculateBurgerPrice(List<Burger> burgers, Burger info)
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
        public static void DisplayBurgers(List<Burger> burgers)
        {
            for (int i = 0 + 0; i < burgers.Count; i++)
            {
                Console.WriteLine("" + (i + 1) + ":    " + burgers[i].name + ", " + burgers[i].price);
            }
        }
        public static void AddProduct(List<Burger> burgers)
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("Enter Burger Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Burger Price: ");
            int price = int.Parse(Console.ReadLine());
            Burger burger = new Burger(name, price);
            burgers.Add(burger);
            using (StreamWriter file = new StreamWriter(@"E:\Week3PDSubmit\SignInWeek3\BurgerFile.txt", true))
            {
                file.WriteLine($"{name},{price}");
            }
        }
        public static void DeleteProduct(List<Burger> burgers, string path1)
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





    }
}
