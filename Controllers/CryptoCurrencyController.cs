using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Data;
using apicrypto.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace apicrypto.Controllers
{
    [Route("api/cryptocurrencies")]
    [ApiController]
    public class CryptoCurrencyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CryptoCurrencyController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll(){
            var currencies = _context.Cryptocurrency.ToList()
            .Select(s => s.ToCryptoCurrencyDto()); // deferred exec

            return Ok(currencies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) {

            var currency = _context.Cryptocurrency.Find(id);
            if(currency == null){
                return NotFound();
            }
            return Ok(currency.ToCryptoCurrencyDto());
        }
        
    }
}