using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.Models;

namespace TaskBoard.Data.Repositories
{
    public interface IBoardRepository
    {
        Task<IEnumerable<Board>> GetAllAsync();
        Task<Board> GetByIdAsync(int id);
        Task AddAsync(Board board);
        Task UpdateAsync(Board board);
        Task DeleteAsync(int id);
    }
}
