using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access.ManagementCenter;
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

        private ManagementCenterProduct FillName(ManagementCenterProduct mp)
        {
            if (mp == null) return null;
            
            mp.Name = _ctx.Products.FirstOrDefault(p => p.Id.Equals(mp.Id)).Name;
            return mp;
        }

        public ManagementCenterProduct Get(int key)
        {
            return FillName(_ctx.ManagementCenterProduct.FirstOrDefault(p => p.Id.Equals(key)));
        }

        public IQueryable<ManagementCenterProduct> Query()
        {
            return _ctx.ManagementCenterProduct;
        }

        public void Create(ManagementCenterProduct obj)
        {
            _ctx.InsertProduct(obj.Id, obj.Name, obj.SupplierId, obj.Price, obj.AvailableAmount);
        }

        public void Update(ManagementCenterProduct obj)
        {
            _ctx.UpdateProduct(obj.Id, obj.AvailableAmount);
        }

        public void Delete(ManagementCenterProduct obj)
        {
            _ctx.DeleteProduct(obj.Id);

        }

        public void Delete(int key)
        {
            Delete(Get(key));
        }
    }
}
