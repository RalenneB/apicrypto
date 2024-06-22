using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apicrypto.Dtos
{
    public class CreateDcaInvestmentRequestDto
    {
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "The type of the crypto should have 3 chars")]
        public string CryptoType { get; set; }
        public int InvestedAmount { get; set; } // how much I currently invest / month
        [Required]
        [Range(1, 1000000000, ErrorMessage = "The crypto price cannot be higher than billions")]
        public int CryptoPrice { get; set; }
    }
}