﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolSMSVaschool.Models.Student
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class student_db_allEntities4 : DbContext
    {
        public student_db_allEntities4()
            : base("name=student_db_allEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aci_lophoc> aci_lophoc { get; set; }
        public virtual DbSet<aci_lophoc_monhoc> aci_lophoc_monhoc { get; set; }
        public virtual DbSet<aci_monhoc> aci_monhoc { get; set; }
    }
}
