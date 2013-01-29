using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework.DataObjects.Mappings
{
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            HasKey(s => s.Id);
            Property(s => s.Name)
                .IsRequired();
        }
    }
}
