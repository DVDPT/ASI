using System;
using DAL.Model.Entities;

namespace DAL.Access
{
    public sealed class SupplierOrderKey
    {
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
    
    }

    public interface ISupplierOrderMapper : IDataMapper<SupplierOrderBase, SupplierOrderKey>
    {
    }
}
