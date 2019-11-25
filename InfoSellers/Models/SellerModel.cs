using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoSellers.Models
{
    public class SellerModel
    {
        public string NIT { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal PenaltyPercentage { get; set; }
    }
}