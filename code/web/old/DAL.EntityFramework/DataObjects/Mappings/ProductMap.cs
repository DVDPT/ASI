using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework.DataObjects.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(p => p.Code);
            Property(p => p.Name)
                .IsRequired();
            Property(p => p.Price)
                .IsRequired();
            Property(p => p.StockQuantity)
                .IsRequired();
            HasRequired(p => p.SupplierC)
                .WithMany(s => s.SuppliedProducts);
        }
    }
}
