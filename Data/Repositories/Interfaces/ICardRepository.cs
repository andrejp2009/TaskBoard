using TaskBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoard.Data.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetAllAsync();
        Task<Card> GetByIdAsync(int id);
        Task AddAsync(Card card);
        Task UpdateAsync(Card card);
        Task DeleteAsync(int id);
    }
}
