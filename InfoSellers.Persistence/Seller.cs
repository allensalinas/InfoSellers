//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Seller
    {
        public int ID { get; set; }
        public string Nit { get; set; }
        public string FullName { get; set; }
        public string SellerAddress { get; set; }
        public string Phone { get; set; }
        public decimal PenaltyPercentage { get; set; }
        public decimal CurrentCommission { get; set; }
        public int RolID { get; set; }
        public bool Active { get; set; }
    
        public virtual Rol Rol { get; set; }
    }
}