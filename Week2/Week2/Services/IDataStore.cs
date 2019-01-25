using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week2.Models;

namespace Week2.Services
{
    public interface IDataStore
    {
        Task<bool> InsertUpdateAsync_Item(Item data);
        Task<bool> AddAsync_Item(Item data);
        Task<bool> UpdateAsync_Item(Item data);
        Task<bool> DeleteAsync_Item(Item data);
        Task<Item> GetAsync_Item(string id);
        Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false);
        //Task AddAsync_Item(Item data);
    }
}
