using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Entities
{
    public class ProductBase
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public Nullable<int> AvailableAmount { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public string Name { get; set; }
    }
}
