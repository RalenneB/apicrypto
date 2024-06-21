using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace apicrypto.Models
{
    public class DcaInvestment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CryptoType { get; set; }

        // public int UnitPrice { get; set; } // tbd in frontend

        public int InvestedAmount { get; set; } // how much I currently invest / month
        public int CryptoPrice { get; set; }
         public List<Comment> Comments {get; set;} = new List<Comment>();
    }
    
}