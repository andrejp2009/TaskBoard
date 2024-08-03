using Microsoft.EntityFrameworkCore;
using TaskBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoard.Data.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly TaskBoardDbContext _context;

        public BoardRepository(TaskBoardDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Board>> GetAllAsync()
        {
            return await _context.Boards.Include(b => b.Lists).ToListAsync();
        }

        public async Task<Board> GetByIdAsync(int id)
        {
            return await _context.Boards.Include(b => b.Lists).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Board board)
        {
            _context.Boards.Update(board);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var board = await _context.Boards.FindAsync(id);
            if (board != null)
            {
                _context.Boards.Remove(board);
                await _context.SaveChangesAsync();
            }
        }
    }
}
