using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Dtos;
using apicrypto.Dtos.Comment;
using apicrypto.Interfaces;
using apicrypto.Mappers;
using apicrypto.Repository;
using Microsoft.AspNetCore.Mvc;

namespace apicrypto.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController: ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IDcaInvestmentRepository _investmentRepo;
        public CommentController(ICommentRepository commentRepo, IDcaInvestmentRepository investmentRepo ) {
            _commentRepo = commentRepo;
            _investmentRepo = investmentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null) 
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{dcaInvestmentId:int}")]
        public async Task<IActionResult> Create([FromRoute] int dcaInvestmentId, CreateCommentDto commentDto )
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            if(!await _investmentRepo.DcaInvestmentExists(dcaInvestmentId))
            {
                return BadRequest("Investment does not exist");
            }
             var commentModel = commentDto.ToCommentFromCreate(dcaInvestmentId);
             await _commentRepo.CreateAsync(commentModel);
             return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate());

            if(comment == null)
            {
               return NotFound("Comment not found");
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var commentModel = await _commentRepo.DeleteAsync(id);

            if(commentModel == null) {
                return NotFound("Comment does not exist");
            }

            return Ok(commentModel);
        }

           

    }
}