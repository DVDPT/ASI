using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Entities
{
    public class SupplierOrderBase
    {
        public System.DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public Nullable<int> OrderAmount { get; set; }
    
    }
}
