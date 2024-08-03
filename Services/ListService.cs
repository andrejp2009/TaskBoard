using TaskBoard.Services.Interfaces;
using TaskBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskBoard.Data.Repositories;

namespace TaskBoard.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;

        public ListService(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<IEnumerable<List>> GetAllListsAsync()
        {
            return await _listRepository.GetAllAsync();
        }

        public async Task<List> GetListByIdAsync(int id)
        {
            return await _listRepository.GetByIdAsync(id);
        }

        public async Task CreateListAsync(List list)
        {
            await _listRepository.AddAsync(list);
        }

        public async Task UpdateListAsync(List list)
        {
            await _listRepository.UpdateAsync(list);
        }

        public async Task DeleteListAsync(int id)
        {
            await _listRepository.DeleteAsync(id);
        }
    }
}
