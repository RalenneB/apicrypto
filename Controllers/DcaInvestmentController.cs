using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Data;
using apicrypto.Helpers;
using apicrypto.Interfaces;
using apicrypto.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace apicrypto.Controllers
{
    [Route("api/dca")]
    [ApiController]
    public class DcaInvestmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IDcaInvestmentRepository _investmentRepo;
        public DcaInvestmentController(ApplicationDbContext context, IDcaInvestmentRepository investmentRepo)
        {
            _investmentRepo = investmentRepo;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query){
            var investments = await _investmentRepo.GetAllAsync();

           var investmentDto = investments.Select(s => s.ToDcaInvestmentDto()); // deferred exec

            return Ok(investments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {

            // var investment = await _context.DcaInvestments.FindAsync(id);
            var investment = await _investmentRepo.GetByIdAsync(id);

            if (investment == null){
                return NotFound();
            }
            return Ok(investment.ToDcaInvestmentDto());
        }

        [HttpGet("{startDate}")]
        public IActionResult GetByStartDate([FromRoute] DateTime startDate) {

            var stDate = _context.DcaInvestments.Find(startDate);
            if(stDate == null){
                return NotFound();
            }
            return Ok(stDate.ToDcaInvestmentDto());
        }

        [HttpGet("{endDate}")]
        public IActionResult GetByEndDate([FromRoute] DateTime endDate) {

            var edDate = _context.DcaInvestments.Find(endDate);
            if(edDate == null){
                return NotFound();
            }
            return Ok(edDate.ToDcaInvestmentDto());
        }

        [HttpGet("{cryptoType}")]
        public IActionResult GetById([FromRoute] string cryptoType) {

            var crypto = _context.DcaInvestments.Find(cryptoType);
            if(crypto == null){
                return NotFound();
            }
            return Ok(crypto.ToDcaInvestmentDto());
        }

        [HttpGet("{investedAmount}")]
        public IActionResult GetByAmount([FromRoute] int investedAmount) {

            var amount = _context.DcaInvestments.Find(investedAmount);
            if(amount == null){
                return NotFound();
            }
            return Ok(amount.ToDcaInvestmentDto());
        }
        
    }
}