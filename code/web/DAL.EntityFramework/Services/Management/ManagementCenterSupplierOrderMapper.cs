using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access.ManagementCenter;
using DAL.Model.ManagementCenter;

namespace DAL.EntityFramework.Services.Management
{
    public class ManagementCenterSupplierOrderMapper : BaseDataMapper<SupplierOrder, SupplierOrderKey>, ISupplierOrderMapper
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterSupplierOrderMapper(ManagementCenterContext ctx)
            : base(ctx.SupplierOrder)
        {
            _ctx = ctx;
        }

        public override SupplierOrder Get(SupplierOrderKey key)
        {
            return _ctx.SupplierOrder.FirstOrDefault(o => o.ProductId.Equals(key.ProductId) &&
                                                          o.SupplierId.Equals(key.SupplierId) &&
                                                          o.OrderDate.Equals(key.OrderDate));
        }
    }
}
