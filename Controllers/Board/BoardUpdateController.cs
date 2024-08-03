using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using TaskBoard.Models;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Controllers.Board
{
    [ApiController]
    [Route("api/board")]
    public class BoardUpdateController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardUpdateController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing board", Description = "Updates an existing board by ID.", Tags = new[] { "Board" })]
        public async Task<IActionResult> UpdateBoard(int id, [FromBody] BoardUpdateRequest boardUpdateRequest)
        {
            if (id != boardUpdateRequest.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var board = new Models.Board
            {
                Id = boardUpdateRequest.Id,
                Name = boardUpdateRequest.Name,
                Description = boardUpdateRequest.Description,
                UserId = boardUpdateRequest.UserId
            };

            await _boardService.UpdateBoardAsync(board);
            return NoContent();
        }

        public class BoardUpdateRequest
        {
            [Required]
            public int Id { get; set; }
            
            [Required]
            public string Name { get; set; }
            
            public string Description { get; set; }
            
            [Required]
            public string UserId { get; set; }
        }
    }
}
