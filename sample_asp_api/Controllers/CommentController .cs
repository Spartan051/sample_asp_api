using Microsoft.AspNetCore.Mvc;
using sample_api.Interfaces;
using sample_api.Mappers;
using sample_api.Models;
using sample_asp_api.Dtos.Comment;
using sample_asp_api.Dtos.CommentDto;

namespace sample_api.Controllers
{

    [Route("api/[controller]")]
    public class CommentController(
        ICommentRepository commentRepository,
        IStockRepository stockRepository
        ) : Controller
    {
        private readonly ICommentRepository _commentRepo = commentRepository;
        private readonly IStockRepository _stockRepo = stockRepository;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Comment? comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null) return NotFound();

            return Ok(comment.ToCommentDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Comment> comments = await _commentRepo.GetAllAsync();

            IEnumerable<CommentDto> commentList = comments.Select((s) => s.ToCommentDto());

            return Ok(commentList);
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create(
            [FromRoute] int stockId,
            [FromBody] CreateCommentDto commentDto
            )
        {
            if(!await _stockRepo.StockExists(stockId))
            {
                return BadRequest("Stock not exist");
            }

            Comment commentModel = commentDto.ToCommentCreateDto(stockId);

            Comment? CreatedCommentModel = await _commentRepo.CreateAsync(commentModel);

            return  CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, CreatedCommentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var commentModel = await _commentRepo.UpdateAsync(id, updateCommentDto.ToCommentUpdateDto());

            if (commentModel == null) return NotFound();

            return Ok(commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Comment? commentModel = await _commentRepo.DeleteAsync(id);

            if (commentModel == null) return NotFound();

            return NoContent();
        }
    }
}
