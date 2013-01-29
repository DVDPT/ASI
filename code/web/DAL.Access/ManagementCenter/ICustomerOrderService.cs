using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.ManagementCenter;

namespace DAL.Access.ManagementCenter
{

    public sealed class CustomerOrderKeys
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    
    }

    public interface ICustomerOrderService : IDataAccess<CustomerOrder, CustomerOrderKeys>
    {
    }
}
