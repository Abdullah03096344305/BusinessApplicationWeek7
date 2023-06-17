using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SignInWeek3.BL;
using SignInWeek3.DL;
using EZInput;
using System.Threading.Tasks;

namespace SignInWeek3.UI
{
    class BurgerUI
    {
        public static void OurStory()
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine("OUR STORY");
            Console.WriteLine("");
            Console.WriteLine("What started as a backyard entrepreneurial ");
            Console.WriteLine("project during lockdown branched out into a ");
            Console.WriteLine("take-out kitchen serving hundreds of burgers a ");
            Console.WriteLine("day. Our original patrons grew from just friends ");
            Console.WriteLine("and family, and our premium beef cuts have");
            Console.WriteLine("been an absolute smash hit.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("FOUNDER  AND  OWNER");
            Console.WriteLine("");
            Console.WriteLine("Our owner Ali’s introduction to burgers was ");
            Console.WriteLine("love at first bite. When he moved to Lahore, ");
            Console.WriteLine("he missed beef-burgers so much he ");
            Console.WriteLine("decided to start making his own!");
            Console.WriteLine("Press any Key to Conitnue ...");
        }

        public static void SmashFeed()
        {
            Console.Clear();
            MenuUI.Header();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t \t \t \t SMASH Feeds is our way of giving back to the community of ");
            Console.WriteLine("\t \t \t \t Lahore which has given so much to us. We pledge to donate ");
            Console.WriteLine("\t \t \t \t 10% of profits back to the community in the most meaningful ");
            Console.WriteLine("\t \t \t \t way we know: offering free burgers to local orphanages, schools, ");
            Console.WriteLine("\t \t \t \t \t and community centers.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("+ + + OUR PARTNERS + + +");
            Console.WriteLine("");
            Console.WriteLine("\t \t Pakistan Society for the Rehabilitation of the Disabled (PSRD)");
            Console.WriteLine("\t \t \t \tBali Memorial Trust");
            Console.WriteLine("\t \t \t \tDar-ul-shafqat");
            Console.WriteLine("Press any Key to Conitnue ...");
        }

        public static void Locations()
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine();
            Console.WriteLine("\t \t \t \t \t \t SPOTS IN CALIFORNIA");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t \t \tCARSON");
            Console.WriteLine();
            Console.WriteLine("\t \t \tCITRUS HEIGHTS");
            Console.WriteLine();
            Console.WriteLine("\t \t \tELK GROVE");
            Console.WriteLine();
            Console.WriteLine("\t \t \tHOLISTER");
            Console.WriteLine();
            Console.WriteLine("\t \t \tMANHATTAN BEACH");
            Console.WriteLine();
            Console.WriteLine("\t \t \tMARINA");
            Console.WriteLine();
            Console.WriteLine("\t \t \tSAN DIEGO");
            Console.WriteLine();
            Console.WriteLine("Press any Key to Conitnue ...");
        }
        public static void Bill( int burgerTotal,int dealTotal)
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();          
            int finalTotal = burgerTotal + dealTotal;

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
        public static void TotalSales( int burgerTotal, int dealTotal)
        {
            Console.Clear();
            MenuUI.Header();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            int finalTotal = burgerTotal + dealTotal;   
            if (finalTotal < 1)
            {
                Console.WriteLine("There is No Sale Today!");
            }
            if (finalTotal > 1)
            {
                Console.WriteLine("Sales");
                Console.WriteLine("Total sale is : " + finalTotal);
            }
            Console.WriteLine("Press any Key to Conitnue ...");
        }
        public static void Delivery(int burgerTotal, int dealTotal)
        {          
            int deliverytotal = burgerTotal + dealTotal;
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
            else if (deliverytotal > 1000 && deliverytotal < 2000)
            {
                Console.WriteLine("                                    Delivery Charges are 350");
                Console.WriteLine();
                Console.WriteLine("                                              Thanks For Purchasing ");
            }
            else if (deliverytotal > 1 && deliverytotal <= 1000)
            {
                Console.WriteLine("                                    Delivery Charges are 150");
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
        public static void DisplayBurgers()
        {
            Console.Clear();
            MenuUI.Header();
            for (int i = 0 + 0; i < BurgerDL.burgers.Count; i++)
            {
                Console.WriteLine();
                Console.SetCursorPosition(2, 20 + i);                   
                Console.WriteLine(i+1 + ":   ");
                Console.SetCursorPosition(20, 20 + i);
                Console.WriteLine(BurgerDL.burgers[i].GetName());
                Console.SetCursorPosition(60, 20 + i);
                Console.WriteLine(BurgerDL.burgers[i].GetPrice());              
            }
           
            
        }

    }
}