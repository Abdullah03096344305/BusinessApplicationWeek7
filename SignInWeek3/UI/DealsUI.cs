using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignInWeek3.BL;
using SignInWeek3.DL;
using System.Threading.Tasks;

namespace SignInWeek3.UI
{
    class DealsUI
    {
        public static void DisplayDeals()
        {
            Console.Clear();
            MenuUI.Header();
            for (int i = 0 + 0; i < DealsDL.deals.Count; i++)
            {
                Console.WriteLine();
                Console.SetCursorPosition(2, 20 + i);
                Console.WriteLine(i + 1 + ":   ");
                Console.SetCursorPosition(20, 20 + i);
                Console.WriteLine(DealsDL.deals[i].GetName());
                Console.SetCursorPosition(90, 20 + i);
                Console.WriteLine(DealsDL.deals[i].GetPrice());
            }
        }

    }
}
