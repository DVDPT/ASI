using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework.DataObjects.Mappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            HasKey(o => new { o.Client, o.Product });
            Property(o => o.Quantity)
                .IsRequired();
            Property(o => o.OrderDate)
                .IsRequired();
        }
    }
}
