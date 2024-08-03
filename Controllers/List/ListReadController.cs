using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using TaskBoard.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;


namespace TaskBoard.Controllers.List
{
    [ApiController]
    [Route("api/lists")]
    [Authorize]
    public class ListReadController : ControllerBase
    {
        private readonly IListService _listService;

        public ListReadController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all lists", Description = "Returns a list of all lists.", Tags = new[] { "List" })]
        public async Task<ActionResult<IEnumerable<ListReadResponse>>> GetLists()
        {
            var lists = await _listService.GetAllListsAsync();
            var listResponses = lists.Select(l => new ListReadResponse
            {
                Id = l.Id,
                Name = l.Name,
                BoardId = l.BoardId
            }).ToList();

            return Ok(listResponses);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a list by ID", Description = "Returns a single list by its ID.", Tags = new[] { "List" })]
        public async Task<ActionResult<ListReadResponse>> GetList(int id)
        {
            var list = await _listService.GetListByIdAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            var listResponse = new ListReadResponse
            {
                Id = list.Id,
                Name = list.Name,
                BoardId = list.BoardId
            };

            return Ok(listResponse);
        }
    }

    public class ListReadResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
    }
}
