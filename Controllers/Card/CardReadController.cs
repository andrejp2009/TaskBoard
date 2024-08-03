using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace TaskBoard.Controllers.Card
{
    [ApiController]
    [Route("api/cards")]
    [Authorize]
    public class CardReadController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardReadController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all cards", Description = "Returns a list of all cards.", Tags = new[] { "Card" })]
        public async Task<ActionResult<IEnumerable<CardReadResponse>>> GetCards()
        {
            var cards = await _cardService.GetAllCardsAsync();
            var cardReadResponses = cards.Select(c => new CardReadResponse
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                ListId = c.ListId
            }).ToList();

            return Ok(cardReadResponses);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a card by ID", Description = "Returns a single card by its ID.", Tags = new[] { "Card" })]
        public async Task<ActionResult<CardReadResponse>> GetCard(int id)
        {
            var card = await _cardService.GetCardByIdAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            var cardResponse = new CardReadResponse
            {
                Id = card.Id,
                Title = card.Title,
                Description = card.Description,
                ListId = card.ListId
            };

            return Ok(cardResponse);
        }
    }

    public class CardReadResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ListId { get; set; }
    }
}
