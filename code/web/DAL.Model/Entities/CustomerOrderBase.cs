using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Entities
{
    public class CustomerOrderBase
    {

        public System.DateTime OrderDate { get; set; }
        public int State { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> OrderAmount { get; set; }

    }
}
