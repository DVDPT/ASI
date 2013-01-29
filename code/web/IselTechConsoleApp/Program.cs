using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.ManagementCenter;

namespace IselTechConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new ManagementCenterContext();
            ctx.Customer.Add(new Customer {Address = "cenas", Email = "a@a.pt"});
            ctx.SaveChanges();

        }
    }
}
