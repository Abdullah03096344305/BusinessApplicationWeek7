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
    class DealsDL
    {
        public static List<Deals> deals = new List<Deals>();
        public static void ReadDealData(List<Deals> deals)
        {
            string path = @"E:\Week3PDSubmit\SignInWeek3\DealFile.txt";
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
                                Deals deal = new Deals(name, price);
                                deals.Add(deal);
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

        public static void UpdateDeal(List<Deals> deals)
        {
            Console.Clear();            
            DealsUI.DisplayDeals();
            Console.WriteLine("Enter the index of the product to update (1 to " + deals.Count + "):");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            if (index >= 0 && index < deals.Count)
            {
                Console.WriteLine("Enter the updated price for " + deals[index].GetName() + ":");
                int updatedPrice = Convert.ToInt32(Console.ReadLine());
                deals[index].SetPrice(updatedPrice);
                Console.WriteLine("Price updated successfully.");
                UpdateDealFile(deals);
            }
            else
            {
                Console.WriteLine("Invalid index. No update performed.");
            }
        }

        public static void UpdateDealFile(List<Deals> deals)
        {
            string path = @"E:\Week3PDSubmit\SignInWeek3\DealFile.txt";
            List<string> lines = new List<string>();
            foreach (Deals deal in deals)
            {
                lines.Add($"{deal.GetName()},{deal.GetPrice()}");
            }
            File.WriteAllLines(path, lines);
            Console.WriteLine("Text file updated successfully.");
        }

        public static void WriteDealToFile(List<Deals> deals, string dealpath)
        {
            using (StreamWriter writer = new StreamWriter(dealpath))
            {
                foreach (Deals deal in deals)
                {
                    writer.WriteLine($"{deal.GetName()},{deal.GetPrice()}");
                }
            }
        }


        public static int CalculateDealPrice(List<Deals> deals, int dealTotal)
        {
            int dealchoice;
            int dealquantity;
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter Your Choice: ");
                dealchoice = Convert.ToInt32(Console.ReadLine());
                if (dealchoice == 0)
                {
                    break;
                }
                Console.Write("Enter Deal Quantity: ");
                dealquantity = Convert.ToInt32(Console.ReadLine());
                if (dealchoice > 0 && dealchoice <= deals.Count)
                {
                    Deals selectedDeal = deals[dealchoice - 1];
                    dealTotal += dealquantity * selectedDeal.GetPrice();
                }
                else
                {
                    Console.WriteLine("Invalid Deal choice. Please try again.");
                }
            }
            return dealTotal;
        }

        public static void AddDealProduct(List<Deals> deals)
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("Enter Deal Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Deal Price: ");
            int price = int.Parse(Console.ReadLine());
            Deals deal = new Deals(name, price);
            deals.Add(deal);
            using (StreamWriter file = new StreamWriter(@"E:\Week3PDSubmit\SignInWeek3\DealFile.txt", true))
            {
                file.WriteLine($"{name},{price}");
            }
        }
        public static void DeleteDealProduct(List<Deals> deals, string dealpath)
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("Current list of Deals:");
            DealsUI.DisplayDeals();
            Console.Write("Enter the index of the Deal to delete: ");
            int indexToDelete;
            if (int.TryParse(Console.ReadLine(), out indexToDelete))
            {
                if (indexToDelete >= 0 && indexToDelete < deals.Count)
                {
                    deals.RemoveAt(indexToDelete - 1);
                    Console.WriteLine("Deal deleted Successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid index. No Deal deleted.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. No Deal deleted.");
            }
            WriteDealToFile(deals, dealpath);
            Console.WriteLine("Updated list of Deals:");
            DealsUI.DisplayDeals();
            
        }
    }
}
