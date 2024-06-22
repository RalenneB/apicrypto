using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicrypto.Models
{
    public class Comment
    {
        public int Id {get; set;}
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? CryptocurrencyId {get; set; }
        public Cryptocurrency? Cryptocurrency {get; set; }
        public int ? DcaInvestmentId {get; set; }
        public DcaInvestment? DcaInvestment {get; set; }


    }
}