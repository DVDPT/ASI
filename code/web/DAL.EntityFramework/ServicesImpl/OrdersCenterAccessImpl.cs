using System;
using System.Data.Entity;
using System.Linq;
using DAL.Access.Common;
using DAL.Access.OrdersCenter;
using DAL.Model.Common;
using DAL.Model.ManagementCenter;
using DAL.Model.OrdersCenter;
using Customer = DAL.Model.OrdersCenter.Customer;

namespace DAL.EntityFramework
{


    public class OrdersCenterProductService : BaseDataAccessService<OrderCenterProduct, int>, IProductService
    {
        private readonly OrdersCenterContext _ctx;

        public OrdersCenterProductService(OrdersCenterContext ctx)
            : base(ctx.OrderCenterProduct)
        {
            _ctx = ctx;
        }

        public override OrderCenterProduct Get(int key)
        {
            return _ctx.OrderCenterProduct.FirstOrDefault(p => p.Id.Equals(key));
        }
    }

    public class OrdersCenterCustomerService : ICustomerService
    {
        private readonly OrdersCenterContext _ctx;

        public OrdersCenterCustomerService(OrdersCenterContext ctx)
        {
            _ctx = ctx;
        }


        public CustomerBase Get(int key)
        {
            return _ctx.Customer.FirstOrDefault(c => c.Id.Equals(key));
        }

        public IQueryable<CustomerBase> Query()
        {
            return _ctx.Customer;
        }

        public void Create(CustomerBase obj)
        {
            throw new NotSupportedException();

        }

        public void Update(CustomerBase obj)
        {
            throw new NotSupportedException();

        }

        public void Delete(CustomerBase obj)
        {
            throw new NotSupportedException();

        }

        public void Delete(int key)
        {
            throw new NotSupportedException();
        }
    }
}
