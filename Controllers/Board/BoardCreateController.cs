using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using TaskBoard.Models;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaskBoard.Controllers.Board
{
    [ApiController]
    [Route("api/board")]
    public class BoardCreateController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardCreateController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new board", Description = "Creates a new board and returns it.", Tags = new[] { "Board" })]
        public async Task<IActionResult> CreateBoard([FromBody] BoardCreateRequest boardCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var board = new Models.Board
            {
                Name = boardCreateRequest.Name,
                Description = boardCreateRequest.Description,
                UserId = boardCreateRequest.UserId
            };

            await _boardService.CreateBoardAsync(board);
            var boardResponse = new BoardResponse
            {
                Id = board.Id,
                Name = board.Name,
                Description = board.Description,
                UserId = board.UserId
            };

            return CreatedAtAction(nameof(BoardReadController.GetBoard), "BoardRead", new { id = board.Id }, boardResponse);
        }

        public class BoardCreateRequest
        {
            [Required]
            public string Name { get; set; }
            
            public string Description { get; set; }
            
            [Required]
            public string UserId { get; set; }
        }

        public class BoardResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string UserId { get; set; }
        }
    }
}
