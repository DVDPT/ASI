using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class ProductService : IProductService
    {
        private ASITechContext _ctx;

        public ProductService(ASITechContext ctx)
        {
            _ctx = ctx;
        }

        public IProduct Get(int key)
        {
            return _ctx.Products.SingleOrDefault(s => s.Code == key);
        }

        public IQueryable<IProduct> Query()
        {
            return _ctx.Products;
        }

        public void Create(IProduct obj)
        {
            _ctx.Products.Add(obj as Product);
        }

        public void Update(IProduct obj)
        {
        }

        public void Delete(IProduct obj)
        {
            _ctx.Products.Remove(obj as Product);
        }

        public void Delete(int key)
        {
            Delete(Get(key));
        }
    }
}
