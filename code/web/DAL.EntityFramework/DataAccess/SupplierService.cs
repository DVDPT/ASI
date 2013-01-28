using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class SupplierService : ISupplierService
    {
        private ASITechContext _ctx;

        public SupplierService(ASITechContext ctx)
        {
            _ctx = ctx;
        }

        public ISupplier Get(int key)
        {
            return _ctx.Suppliers.SingleOrDefault(s => s.Id == key);
        }

        public IQueryable<ISupplier> Query()
        {
            return _ctx.Suppliers;
        }

        public void Create(ISupplier obj)
        {
            _ctx.Suppliers.Add(obj as Supplier);
        }

        public void Update(ISupplier obj)
        {
        }

        public void Delete(ISupplier obj)
        {
            _ctx.Suppliers.Remove(obj as Supplier);
        }

        public void Delete(int key)
        {
            Delete(Get(key));
        }
    }
}
