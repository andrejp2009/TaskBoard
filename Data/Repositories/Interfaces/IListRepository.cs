using TaskBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoard.Data.Repositories
{
    public interface IListRepository
    {
        Task<IEnumerable<List>> GetAllAsync();
        Task<List> GetByIdAsync(int id);
        Task AddAsync(List list);
        Task UpdateAsync(List list);
        Task DeleteAsync(int id);
    }
}
