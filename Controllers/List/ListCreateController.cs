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
    public class ListCreateController : ControllerBase
    {
        private readonly IListService _listService;

        public ListCreateController(IListService listService)
        {
            _listService = listService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new list", Description = "Creates a new list and returns it.", Tags = new[] { "List" })]
        public async Task<IActionResult> CreateList([FromBody] ListCreateRequest listCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var list = new Models.List
            {
                Name = listCreateRequest.Name,
                BoardId = listCreateRequest.BoardId
            };

            await _listService.CreateListAsync(list);
            var listResponse = new ListCreateResponse
            {
                Id = list.Id,
                Name = list.Name,
                BoardId = list.BoardId
            };

            return CreatedAtAction(nameof(ListReadController.GetList), "ListRead", new { id = list.Id }, listResponse);
        }
    }

    public class ListCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int BoardId { get; set; }
    }

    public class ListCreateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
    }
}
