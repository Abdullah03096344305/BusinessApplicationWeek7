using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignInWeek3.DL;
using SignInWeek3.UI;
using System.Threading.Tasks;

namespace SignInWeek3.BL
{
    class Deals : Food
    {
        public Deals(string name, int price) : base(name, price)
        {
        }
    }
}
