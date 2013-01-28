using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class Order : IOrder
    {
        public int ProductId { get; set; }
        public IProduct Product { get; set; }

        public int ClientId { get; set; }
        public IClient Client { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
