using TaskBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskBoard.Services.Interfaces
{
    public interface IListService
    {
        Task<IEnumerable<List>> GetAllListsAsync();
        Task<List> GetListByIdAsync(int id);
        Task CreateListAsync(List list);
        Task UpdateListAsync(List list);
        Task DeleteListAsync(int id);
    }
}
