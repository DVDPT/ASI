using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EntityFramework.Services.Management;
using DAL.EntityFramework.Services.Orders;
using DAL.Model.ManagementCenter;
using DAL.Model.OrdersCenter;

namespace IselTechConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new ManagementCenterContext();
            var xpto  = p.Product.First();
            OrdersCenterContext c;
            var a = new OrdersCenterProductMapper(c = new OrdersCenterContext());

            var prod2 = c.Product.First(e => e.Id == 1);
            var cc = c.Customer.First();
            var prod = a.Get(1);
            var x = a.Query().ToList();

            var aa = prod;
            prod.AvailableAmount = 123321;
            a.Update(prod);
            c.SaveChanges();
        }
    }
}
