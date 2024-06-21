using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicrypto.Helpers
{
    public class QueryObject
    {
        public string? CryptoType { get; set; } = null;
        public DateTime? StartDate { get; set; } = null;

        public DateTime? EndDate { get; set; } = null;

        public int? InvestedAmount { get; set; } = null;

        public int? CryptoPrice { get; set; } = null;

        
    }
}