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
    
    public partial class SupplierOrder
    {
        public System.DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public Nullable<int> OrderAmount { get; set; }
    
        public virtual ManagementCenterProduct ManagementCenterProduct { get; set; }
        public virtual ProductSupplier ProductSupplier { get; set; }
    }
}