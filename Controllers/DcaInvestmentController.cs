using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Data;
using apicrypto.Dtos;
using apicrypto.Dtos.DcaInvestmentDto;
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
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var investments = await _investmentRepo.GetAllAsync(query);

            var investmentDto = investments.Select(s => s.ToDcaInvestmentDto()); // deferred exec

            return Ok(investments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
                

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDcaInvestmentRequestDto dcaIntvestmentDto)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);
                
            var dcaInvestmentModel = dcaIntvestmentDto.ToDcaInvestmentFromCreateDTO();
            await _investmentRepo.CreateAsync(dcaInvestmentModel);

            return CreatedAtAction(nameof(GetById), new { id = dcaInvestmentModel.Id}, dcaInvestmentModel.ToDcaInvestmentDto()) ;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDcaInvestmentRequestDto updateDto )
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var dcaInvestmentModel = await _investmentRepo.UpdateAsync(id, updateDto);

            if(dcaInvestmentModel == null)
             { 
                return NotFound();

            }


            return Ok(dcaInvestmentModel.ToDcaInvestmentDto());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var dcaInvestmentModel = _investmentRepo.DeleteAsync(id);

            if (dcaInvestmentModel == null) 
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}