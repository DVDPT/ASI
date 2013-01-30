using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.ManagementCenter;

namespace DAL.Access.ManagementCenter
{
    public sealed class SupplierOrderKey
    {
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
    
    }

    public interface ISupplierOrderMapper : IDataMapper<SupplierOrder, SupplierOrderKey>
    {
    }
}
