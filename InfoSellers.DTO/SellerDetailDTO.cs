using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.DTO
{
    public class SellerDetailDTO: SellerDTO
    {
        public int CommissionTypeID { get; set; }
        public string RolName { get; set; }
        public string CommissionTypeName { get; set; }
        public decimal CommissionValue { get; set; }
    }
}