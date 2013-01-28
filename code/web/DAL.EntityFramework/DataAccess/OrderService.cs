using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class OrderService : IOrderService
    {
        private ASITechContext _ctx;

        public OrderService(ASITechContext ctx)
        {
            _ctx = ctx;
        }

        public IOrder Get(KeyValuePair<int, int> key)
        {
            return _ctx.Orders.SingleOrDefault(o => o.ProductId == key.Key && o.ClientId == key.Value);
        }

        public IQueryable<IOrder> Query()
        {
            return _ctx.Orders;
        }

        public void Create(IOrder obj)
        {
            _ctx.Orders.Add(obj as Order);
        }

        public void Update(IOrder obj)
        {
        }

        public void Delete(IOrder obj)
        {
            _ctx.Orders.Remove(obj as Order);
        }

        public void Delete(KeyValuePair<int, int> key)
        {
            Delete(Get(key));
        }
    }
}
