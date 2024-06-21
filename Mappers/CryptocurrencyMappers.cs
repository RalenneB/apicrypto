using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Dtos.Comment;
using apicrypto.Models;

namespace apicrypto.Mappers
{
    public static class CryptocurrencyMappers
    {
        public static CryptocurrencyDto ToCryptoCurrencyDto(this Cryptocurrency cryptocurrencyModel)
        {
            return new CryptocurrencyDto 
            {
                Id = cryptocurrencyModel.Id,
                Symbol = cryptocurrencyModel.Symbol,
                Name = cryptocurrencyModel.Name,
                Price = cryptocurrencyModel.Price,
            };
        }
    }
}