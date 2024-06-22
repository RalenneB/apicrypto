using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Dtos;
using apicrypto.Dtos.Comment;
using apicrypto.Models;

namespace apicrypto.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto( this Comment commentModel) 
        {
            return new CommentDto {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                CryptocurrencyId = commentModel.CryptocurrencyId,
                DcaInvestmentId = commentModel.DcaInvestmentId,
            };
        }

        public static Comment ToCommentFromCreate( this CreateCommentDto commentDto, int dcaInvestmentId) 
        // + int cryptocurrencyId
        {
            return new Comment {
                Title = commentDto.Title,
                Content = commentDto.Content,
                CreatedOn = commentDto.CreatedOn,
                // CryptocurrencyId = cryptocurrencyId,
                DcaInvestmentId = dcaInvestmentId,
            };
        }


         public static Comment ToCommentFromUpdate( this UpdateCommentRequestDto commentDto) 
        // + int cryptocurrencyId
        {
            return new Comment {
                Title = commentDto.Title,
                Content = commentDto.Content,
                CreatedOn = commentDto.CreatedOn,
            };
        }
    }
}