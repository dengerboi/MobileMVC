﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class LTIMVC2Entities1 : DbContext
    {
        public LTIMVC2Entities1()
            : base("name=LTIMVC2Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<OrderInfo> OrderInfoes { get; set; }
        public DbSet<Product> Products { get; set; }
    
        public virtual ObjectResult<sp_SelectProductsByID_Result> sp_SelectProductsByID(Nullable<int> pid)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SelectProductsByID_Result>("sp_SelectProductsByID", pidParameter);
        }
    
        public virtual int sp_UpdateProduct(Nullable<int> pid, string pname, string descr)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            var pnameParameter = pname != null ?
                new ObjectParameter("pname", pname) :
                new ObjectParameter("pname", typeof(string));
    
            var descrParameter = descr != null ?
                new ObjectParameter("descr", descr) :
                new ObjectParameter("descr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateProduct", pidParameter, pnameParameter, descrParameter);
        }
    
        public virtual ObjectResult<sp_SelectOrderByID_Result> sp_SelectOrderByID(Nullable<int> oid)
        {
            var oidParameter = oid.HasValue ?
                new ObjectParameter("oid", oid) :
                new ObjectParameter("oid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SelectOrderByID_Result>("sp_SelectOrderByID", oidParameter);
        }
    }
}
