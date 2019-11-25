using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.DTO
{
    public class SellerDTO
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
    }
}
