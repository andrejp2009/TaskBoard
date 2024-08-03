using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace TaskBoard.Controllers.Card
{
    [ApiController]
    [Route("api/cards")]
    [Authorize]
    public class CardDeleteController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardDeleteController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a card", Description = "Deletes a card by ID.", Tags = new[] { "Card" })]
        public async Task<IActionResult> DeleteCard(int id)
        {
            await _cardService.DeleteCardAsync(id);
            return NoContent();
        }
    }
}
