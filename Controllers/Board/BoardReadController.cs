using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskBoard.Controllers.Board
{
    [ApiController]
    [Route("api/board")]
    public class BoardReadController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardReadController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all boards", Description = "Returns a list of all boards.", Tags = new[] { "Board" })]
        public async Task<ActionResult<IEnumerable<BoardResponse>>> GetBoards()
        {
            var boards = await _boardService.GetAllBoardsAsync();
            var boardResponses = boards.Select(b => new BoardResponse
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description
            }).ToList();

            return Ok(boardResponses);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a board by ID", Description = "Returns a single board by its ID.", Tags = new[] { "Board" })]
        public async Task<ActionResult<BoardResponse>> GetBoard(int id)
        {
            var board = await _boardService.GetBoardByIdAsync(id);
            if (board == null)
            {
                return NotFound();
            }

            var boardResponse = new BoardResponse
            {
                Id = board.Id,
                Name = board.Name,
                Description = board.Description
            };

            return Ok(boardResponse);
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
