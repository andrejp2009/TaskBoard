using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.Models;

namespace TaskBoard.Services.Interfaces
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> GetAllBoardsAsync();
        Task<Board> GetBoardByIdAsync(int id);
        Task CreateBoardAsync(Board board);
        Task UpdateBoardAsync(Board board);
        Task DeleteBoardAsync(int id);
    }
}
