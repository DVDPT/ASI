using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access;
using DAL.Model.Entities;
using DAL.Model.ManagementCenter;
using DAL.Model.OrdersCenter;

namespace DAL.EntityFramework.Services.Orders
{
    public class OrdersCenterProductMapper : BaseDataMapper<ProductBase,Product, int>, IProductMapper
    {
        private readonly OrdersCenterContext _ctx;

        public OrdersCenterProductMapper(OrdersCenterContext ctx)
            : base(ctx.Product)
        {
            _ctx = ctx;
        }

        public override ProductBase Get(int key)
        {
            return _ctx.OrderCenterProduct.FirstOrDefault(p => p.Id.Equals(key));
        }
    }
}
