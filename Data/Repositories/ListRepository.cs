using Microsoft.EntityFrameworkCore;
using TaskBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TaskBoard.Data.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly TaskBoardDbContext _context;

        public ListRepository(TaskBoardDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<List>> GetAllAsync()
        {
            return await _context.Lists.Include(l => l.Cards).ToListAsync();
        }

        public async Task<List> GetByIdAsync(int id)
        {
            return await _context.Lists.Include(l => l.Cards).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddAsync(List list)
        {
            await _context.Lists.AddAsync(list);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(List list)
        {
            _context.Lists.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var list = await _context.Lists.FindAsync(id);
            if (list != null)
            {
                _context.Lists.Remove(list);
                await _context.SaveChangesAsync();
            }
        }
    }
}