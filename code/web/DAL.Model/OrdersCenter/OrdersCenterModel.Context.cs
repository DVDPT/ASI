﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DAL.Model.Entities;
using DAL.Model.ManagementCenter;

namespace DAL.Model.OrdersCenter
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OrdersCenterContext : DbContext
    {
        public OrdersCenterContext()
            : base("name=OrdersCenterContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CustomerBase> Customer { get; set; }
        public DbSet<OrderCenterProduct> OrderCenterProduct { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
