using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class Product : IProduct
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int StockQuantity { get; set; }

        public ISupplier Supplier
        {
            get { return SupplierC; }

            set { SupplierC = value as Supplier; }
        }

        public virtual Supplier SupplierC { get; set; }
    }
}
