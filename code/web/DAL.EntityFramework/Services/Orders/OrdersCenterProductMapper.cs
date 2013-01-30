using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access.OrdersCenter;
using DAL.Model.OrdersCenter;

namespace DAL.EntityFramework.Services.Orders
{
    public class OrdersCenterProductMapper : BaseDataMapper<OrderCenterProduct, int>, IProductMapper
    {
        private readonly OrdersCenterContext _ctx;

        public OrdersCenterProductMapper(OrdersCenterContext ctx)
            : base(ctx.OrderCenterProduct)
        {
            _ctx = ctx;
        }

        public override OrderCenterProduct Get(int key)
        {
            return _ctx.OrderCenterProduct.FirstOrDefault(p => p.Id.Equals(key));
        }
    }
}
