using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicrypto.Dtos.Comment
{
    public class CryptocurrencyDto
    {
         public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        
    }
}