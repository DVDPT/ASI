using System;
using DAL.Model.Entities;
using DAL.Model.ManagementCenter;

namespace DAL.Access
{

    public sealed class CustomerOrderKeys
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    
    }

    public interface ICustomerOrderMapper : IDataMapper<CustomerOrderBase, CustomerOrderKeys>
    {
    }
}
