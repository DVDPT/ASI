using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EntityFramework.Services.Management;
using DAL.Model.ManagementCenter;
using DAL.Model.OrdersCenter;

namespace IselTechConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementCenterContext c;
            var a = new ManagementCenterProductMapper(c=new ManagementCenterContext());

            var prod2 = c.Products.First(e => e.Id == 1);

            var prod = a.Get(1);
            var x = a.Query().ToList();

            var aa = prod;
            prod.AvailableAmount = 123321;
            a.Update(prod);
            c.SaveChanges();
        }
    }
}
