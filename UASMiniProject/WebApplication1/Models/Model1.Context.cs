﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UniversityAdmissionSystemEntities : DbContext
    {
        public UniversityAdmissionSystemEntities()
            : base("name=UniversityAdmissionSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ApplicationForm> ApplicationForms { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<ProgramsOffered> ProgramsOffereds { get; set; }
        public virtual DbSet<ProgramsScheduled> ProgramsScheduleds { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
