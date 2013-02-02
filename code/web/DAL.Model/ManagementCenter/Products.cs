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
    
    public partial class Products
    {
        public Products()
        {
            this.CustomerOrder = new HashSet<CustomerOrder>();
            this.SupplierOrder = new HashSet<SupplierOrder>();
        }

        
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ProductSupplier ProductSupplier { get; set; }
        public virtual ICollection<SupplierOrder> SupplierOrder { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public Nullable<int> AvailableAmount { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public string Name { get; set; }
    }
}