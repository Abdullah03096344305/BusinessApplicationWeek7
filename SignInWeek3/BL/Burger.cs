using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignInWeek3.UI;
using System.Threading.Tasks;

namespace SignInWeek3.BL
{
    class Burger
    {
        public string name;
        public int price;
        public int burgertotal;
        public Burger(int burgertotal)
        {
            this.burgertotal = burgertotal;
        }
        public Burger(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

    }
}
