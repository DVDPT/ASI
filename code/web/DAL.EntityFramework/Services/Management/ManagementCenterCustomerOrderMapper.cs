using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access;
using DAL.Model.Entities;
using DAL.Model.ManagementCenter;

namespace DAL.EntityFramework.Services.Management
{
    public class ManagementCenterCustomerOrderMapper : BaseDataMapper<CustomerOrderBase,CustomerOrder, CustomerOrderKeys>, ICustomerOrderMapper
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterCustomerOrderMapper(ManagementCenterContext ctx)
            : base(ctx.CustomerOrder)
        {
            _ctx = ctx;
        }

        public override CustomerOrderBase Get(CustomerOrderKeys key)
        {
            return _ctx.CustomerOrder.FirstOrDefault(c => c.CustomerId.Equals(key.CustomerId) &&
                                                          c.OrderDate.Equals(key.OrderDate) &&
                                                          c.ProductId.Equals(key.ProductId));
        }
    }
}
