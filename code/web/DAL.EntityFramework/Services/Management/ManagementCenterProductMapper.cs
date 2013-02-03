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
    public class ManagementCenterProductMapper : IProductMapper
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterProductMapper(ManagementCenterContext ctx)
        {
            _ctx = ctx;
        }

        public ProductBase Get(int key)
        {
            return _ctx.Product.AsNoTracking().FirstOrDefault(p => p.Id.Equals(key));
        }

        public IQueryable<ProductBase> Query()
        {
            return _ctx.ManagementCenterProduct.AsNoTracking();
        }

        public void Create(ProductBase obj)
        {
            _ctx.sp_InsertProduct(obj.Id, obj.Name, obj.SupplierId, obj.Price, obj.AvailableAmount);
        }

        public void Update(ProductBase obj)
        {
            _ctx.sp_UpdateProduct(obj.Id, obj.AvailableAmount);
        }

        public void Delete(ProductBase obj)
        {
            _ctx.sp_DeleteProduct(obj.Id);

        }

        public void Delete(int key)
        {
            Delete(Get(key));
        }
    }
}
