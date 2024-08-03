using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using TaskBoard.Models;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Controllers.Card
{
    [ApiController]
    [Route("api/cards")]
    [Authorize]
    public class CardUpdateController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardUpdateController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing card", Description = "Updates an existing card by ID.", Tags = new[] { "Card" })]
        public async Task<IActionResult> UpdateCard(int id, [FromBody] CardUpdateRequest cardUpdateRequest)
        {
            if (id != cardUpdateRequest.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = new Models.Card
            {
                Id = cardUpdateRequest.Id,
                Title = cardUpdateRequest.Title,
                Description = cardUpdateRequest.Description,
                ListId = cardUpdateRequest.ListId
            };

            await _cardService.UpdateCardAsync(card);
            return NoContent();
        }
    }

    public class CardUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int ListId { get; set; }
    }
}
