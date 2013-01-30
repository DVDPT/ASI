using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access.Common;
using DAL.Model.Common;
using DAL.Model.ManagementCenter;

namespace DAL.EntityFramework.Services.Management
{
    public class ManagementCenterCustomerMapper : ICustomerMapper
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterCustomerMapper(ManagementCenterContext ctx)
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
            _ctx.Customer.Add((Customer)obj);

        }

        public void Update(CustomerBase obj)
        {

        }

        public void Delete(CustomerBase obj)
        {
            _ctx.Customer.Remove((Customer)obj);
        }

        public void Delete(int key)
        {
            Delete(Get(key));
        }
    }
}
