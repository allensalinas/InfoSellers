﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfoSellers.Persistence
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InfoSellersEntities : DbContext
    {
        public InfoSellersEntities()
            : base("name=InfoSellersEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CommissionType> CommissionType { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<View_Sellers> View_Sellers { get; set; }
    }
}