using TaskBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoard.Services.Interfaces
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetAllCardsAsync();
        Task<Card> GetCardByIdAsync(int id);
        Task CreateCardAsync(Card card);
        Task UpdateCardAsync(Card card);
        Task DeleteCardAsync(int id);
    }
}
