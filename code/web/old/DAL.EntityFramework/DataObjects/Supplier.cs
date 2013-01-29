using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class Supplier : ISupplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> SuppliedProducts { get; set; }
    }
}
