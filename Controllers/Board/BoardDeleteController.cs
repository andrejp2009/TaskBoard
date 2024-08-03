using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskBoard.Controllers.Board
{
    [ApiController]
    [Route("api/board")]
    public class BoardDeleteController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardDeleteController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a board", Description = "Deletes a board by ID.", Tags = new[] { "Board" })]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            await _boardService.DeleteBoardAsync(id);
            return NoContent();
        }
    }
}
