using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrder
    {
        IProduct Product { get; set; }

        IClient Client { get; set; }

        int Quantity { get; set; }

        DateTime OrderDate { get; set; }
    }
}
