using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace TaskBoard.Controllers.List
{
    [ApiController]
    [Route("api/lists")]
    [Authorize]
    public class ListDeleteController : ControllerBase
    {
        private readonly IListService _listService;

        public ListDeleteController(IListService listService)
        {
            _listService = listService;
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a list", Description = "Deletes a list by ID.", Tags = new[] { "List" })]
        public async Task<IActionResult> DeleteList(int id)
        {
            await _listService.DeleteListAsync(id);
            return NoContent();
        }
    }
}
