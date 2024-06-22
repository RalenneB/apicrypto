using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Dtos;
using apicrypto.Dtos.Comment;
using apicrypto.Models;

namespace apicrypto.Mappers
{
    public static class DcaInvestmentMappers
    {
        public static DcaInvestmentDto ToDcaInvestmentDto(this DcaInvestment DcaInvestmentModel)
        {
            return new DcaInvestmentDto 
            {
                Id = DcaInvestmentModel.Id,
                StartDate = DcaInvestmentModel.StartDate,
                EndDate = DcaInvestmentModel.EndDate,
                CryptoType = DcaInvestmentModel.CryptoType,
                InvestedAmount = DcaInvestmentModel.InvestedAmount,
                CryptoPrice = DcaInvestmentModel.CryptoPrice,
                Comments = DcaInvestmentModel.Comments.Select( c => c.ToCommentDto()).ToList()
            };
        }
        public static DcaInvestment ToDcaInvestmentFromCreateDTO( this CreateDcaInvestmentRequestDto dcaInvestmentDto) 
        {
            return new DcaInvestment {
              
                StartDate = dcaInvestmentDto.StartDate,
                EndDate = dcaInvestmentDto.EndDate,
                CryptoType = dcaInvestmentDto.CryptoType,
                InvestedAmount = dcaInvestmentDto.InvestedAmount,
                CryptoPrice = dcaInvestmentDto.CryptoPrice,

            };
        }
    }
}