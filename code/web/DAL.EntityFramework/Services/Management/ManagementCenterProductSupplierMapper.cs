using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access.ManagementCenter;
using DAL.Model.ManagementCenter;

namespace DAL.EntityFramework.Services.Management
{
    public class ManagementCenterProductSupplierMapper : BaseDataMapper<ProductSupplier, int>, IProductSupplierMapper
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterProductSupplierMapper(ManagementCenterContext ctx)
            : base(ctx.ProductSupplier)
        {
            _ctx = ctx;
        }

        public override ProductSupplier Get(int key)
        {
            return _ctx.ProductSupplier.FirstOrDefault(s => s.Id.Equals(key));
        }
    }
}
