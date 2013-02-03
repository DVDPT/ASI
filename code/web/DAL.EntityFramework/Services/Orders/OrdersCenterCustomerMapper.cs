using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access;
using DAL.Model.Entities;
using DAL.Model.OrdersCenter;
using CustomerBase = DAL.Model.Entities.CustomerBase;

namespace DAL.EntityFramework.Services.Orders
{
    public class OrdersCenterCustomerMapper : ICustomerMapper
    {
        private readonly OrdersCenterContext _ctx;

        public OrdersCenterCustomerMapper(OrdersCenterContext ctx)
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
