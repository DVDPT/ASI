using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProduct
    {
        int Code { get; set; }

        string Name { get; set; }

        double Price { get; set; }

        int StockQuantity { get; set; }

        ISupplier Supplier { get; set; }
    }
}
