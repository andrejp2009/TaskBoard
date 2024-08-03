using TaskBoard.Services.Interfaces;
using TaskBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.Data.Repositories;

namespace TaskBoard.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<IEnumerable<Board>> GetAllBoardsAsync()
        {
            return await _boardRepository.GetAllAsync();
        }

        public async Task<Board> GetBoardByIdAsync(int id)
        {
            return await _boardRepository.GetByIdAsync(id);
        }

        public async Task CreateBoardAsync(Board board)
        {
            await _boardRepository.AddAsync(board);
        }

        public async Task UpdateBoardAsync(Board board)
        {
            await _boardRepository.UpdateAsync(board);
        }

        public async Task DeleteBoardAsync(int id)
        {
            await _boardRepository.DeleteAsync(id);
        }
    }
}
