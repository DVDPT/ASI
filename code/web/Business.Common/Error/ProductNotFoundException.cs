using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common.Error
{
    public class ProductNotFoundException : Exception
    {
        public int ProductId { get;  set; }

        public ProductNotFoundException(int productId)
            : base("No product with id " + productId)
        {
            ProductId = productId;
        }
    }
}
