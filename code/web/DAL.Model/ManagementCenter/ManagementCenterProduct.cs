//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DAL.Model.Entities;

namespace DAL.Model.ManagementCenter
{
    using System;
    using System.Collections.Generic;
    
    public partial class ManagementCenterProduct : ProductBase
    {
        public ManagementCenterProduct()
        {
            this.CustomerOrder = new HashSet<CustomerOrder>();
            this.SupplierOrder = new HashSet<SupplierOrder>();
        }
    
    
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ProductSupplier ProductSupplier { get; set; }
        public virtual ICollection<SupplierOrder> SupplierOrder { get; set; }
    }
}
