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
    public class CardCreateController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardCreateController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new card", Description = "Creates a new card and returns it.", Tags = new[] { "Card" })]
        public async Task<IActionResult> CreateCard([FromBody] CardCreateRequest cardCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = new Models.Card
            {
                Title = cardCreateRequest.Title,
                Description = cardCreateRequest.Description,
                ListId = cardCreateRequest.ListId
            };

            await _cardService.CreateCardAsync(card);
            var cardResponse = new CardCreateResponse
            {
                Id = card.Id,
                Title = card.Title,
                Description = card.Description,
                ListId = card.ListId
            };

            return CreatedAtAction(nameof(CardReadController.GetCard), "CardRead", new { id = card.Id }, cardResponse);
        }
    }

    public class CardCreateRequest
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int ListId { get; set; }
    }

    public class CardCreateResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ListId { get; set; }
    }
}
