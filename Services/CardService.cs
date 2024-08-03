using TaskBoard.Services.Interfaces;
using TaskBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.Data.Repositories;

namespace TaskBoard.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<Card>> GetAllCardsAsync()
        {
            return await _cardRepository.GetAllAsync();
        }

        public async Task<Card> GetCardByIdAsync(int id)
        {
            return await _cardRepository.GetByIdAsync(id);
        }

        public async Task CreateCardAsync(Card card)
        {
            await _cardRepository.AddAsync(card);
        }

        public async Task UpdateCardAsync(Card card)
        {
            await _cardRepository.UpdateAsync(card);
        }

        public async Task DeleteCardAsync(int id)
        {
            await _cardRepository.DeleteAsync(id);
        }
    }
}
