using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace apicrypto.Dtos.Comment
{
    public class DcaInvestmentDto
    {
         public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CryptoType { get; set; }
        
        public int InvestedAmount { get; set; } // how much I currently invest / month
        public int CryptoPrice { get; set; }

        
    }
}