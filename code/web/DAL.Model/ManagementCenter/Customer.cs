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
    
    public partial class Customer : CustomerBase
    {
        public Customer()
        {
            this.CustomerOrder = new HashSet<CustomerOrder>();
        }
    
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
    }
}
