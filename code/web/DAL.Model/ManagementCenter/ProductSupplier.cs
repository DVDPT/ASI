//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Model.ManagementCenter
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSupplier
    {
        public ProductSupplier()
        {
            this.ManagementCenterProduct = new HashSet<ManagementCenterProduct>();
            this.SupplierOrder = new HashSet<SupplierOrder>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    
        public virtual ICollection<ManagementCenterProduct> ManagementCenterProduct { get; set; }
        public virtual ICollection<SupplierOrder> SupplierOrder { get; set; }
    }
}