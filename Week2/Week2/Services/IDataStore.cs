﻿using System;
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
        // Implement Monster
        Task<bool> InsertUpdateAsync_Character(Character data);
        Task<bool> AddAsync_Character(Character data);
        Task<bool> UpdateAsync_Character(Character data);
        Task<bool> DeleteAsync_Character(Character data);
        Task<Character> GetAsync_Character(string id);
        Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false);
    }
}
