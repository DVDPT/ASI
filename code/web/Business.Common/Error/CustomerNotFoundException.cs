using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common.Error
{
    public  class CustomerNotFoundException : Exception
    {
        public int CustomerId { get; set; }

        public CustomerNotFoundException(int id)
            : base("No customer with id " + id)
        {
            CustomerId = id;
        }
    }
}
