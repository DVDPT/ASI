using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.ManagementCenter;
using DAL.Model.OrdersCenter;

namespace IselTechConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new OrdersCenterContext();
            var c = ctx.Customer.ToList();
            var xot = c;

            var ctx2 = new ManagementCenterContext();
            var x = ctx2.Customer.ToList();
            var s = x;

        }
    }
}
