using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using TaskBoard.Models;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;


namespace TaskBoard.Controllers.List
{
    [ApiController]
    [Route("api/lists")]
    [Authorize]
    public class ListUpdateController : ControllerBase
    {
        private readonly IListService _listService;

        public ListUpdateController(IListService listService)
        {
            _listService = listService;
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing list", Description = "Updates an existing list by ID.", Tags = new[] { "List" })]
        public async Task<IActionResult> UpdateList(int id, [FromBody] ListUpdateRequest listUpdateRequest)
        {
            if (id != listUpdateRequest.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var list = new Models.List
            {
                Id = listUpdateRequest.Id,
                Name = listUpdateRequest.Name,
                BoardId = listUpdateRequest.BoardId
            };

            await _listService.UpdateListAsync(list);
            return NoContent();
        }
    }

    public class ListUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int BoardId { get; set; }
    }
}
