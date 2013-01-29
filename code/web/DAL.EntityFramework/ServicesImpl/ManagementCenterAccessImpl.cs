using System.Data.Entity;
using System.Linq;
using DAL.Access.Common;
using DAL.Access.ManagementCenter;
using DAL.Model.Common;
using DAL.Model.ManagementCenter;

namespace DAL.EntityFramework
{

    public class ManagementCenterSupplierOrderService : BaseDataAccessService<SupplierOrder, SupplierOrderKey>, ISupplierOrderService
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterSupplierOrderService(ManagementCenterContext ctx)
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


    public class ManagementCenterProductSupplierService : BaseDataAccessService<ProductSupplier, int>, IProductSupplierService
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterProductSupplierService(ManagementCenterContext ctx)
            : base(ctx.ProductSupplier)
        {
            _ctx = ctx;
        }

        public override ProductSupplier Get(int key)
        {
            return _ctx.ProductSupplier.FirstOrDefault(s => s.Id.Equals(key));
        }
    }

    public class ManagementCenterCustomerOrderService : BaseDataAccessService<CustomerOrder, CustomerOrderKeys>, ICustomerOrderService
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterCustomerOrderService(ManagementCenterContext ctx)
            : base(ctx.CustomerOrder)
        {
            _ctx = ctx;
        }

        public override CustomerOrder Get(CustomerOrderKeys key)
        {
            return _ctx.CustomerOrder.FirstOrDefault(c => c.CustomerId.Equals(key.CustomerId) &&
                                                          c.OrderDate.Equals(key.OrderDate) &&
                                                          c.ProductId.Equals(key.ProductId));
        }
    }

    public class ManagementCenterProductService : IProductService
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterProductService(ManagementCenterContext ctx)
        {
            _ctx = ctx;
        }

        public ManagementCenterProduct Get(int key)
        {
            return _ctx.ManagementCenterProduct.FirstOrDefault(p => p.Id.Equals(key));
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
            throw new System.NotImplementedException();
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
    public class ManagementCenterCustomerService : ICustomerService
    {
        private readonly ManagementCenterContext _ctx;

        public ManagementCenterCustomerService(ManagementCenterContext ctx)
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
