﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Week2.Models;
using Week2.ViewModels;

using Xamarin.Forms;

namespace Week2.Services
{
    public sealed class SQLDataStore : IDataStore
    {
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static SQLDataStore _instance;

        public static SQLDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLDataStore();
                }
                return _instance;
            }
        }

        private SQLDataStore()
        {
            // Implement
            // CreateTables();
        }

        // Create the Database Tables
        private void CreateTables()
        {
            // Implement
        }

        // Delete the Datbase Tables by dropping them
        private void DeleteTables()
        {
            // Implement
        }

        // Tells the View Models to update themselves.
        private void NotifyViewModelsOfDataChange()
        {
            // Implement
        }

        public void InitializeDatabaseNewTables()
        {
            // Implement

            // Delete the tables

            // make them again

            // Populate them

            // Tell View Models they need to refresh

        }

        private async void InitializeSeedData()
        {
            // Implement

        }
        /*
        #region Item
        // Item

        // Add InsertUpdateAsync_Item Method

        // Check to see if the item exists
        // Add your code here.

        // If it does not exist, then Insert it into the DB
        // Add your code here.
        // return true;

        // If it does exist, Update it into the DB
        // Add your code here
        // return true;

        // If you got to here then return false;

        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {
            // Implement

            return false;
        }

        public async Task<bool> AddAsync_Item(Item data)
        {
            // Implement

            return false;
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            // Implement

            return false;
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            // Implement

            return false;
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            // Implement
            return null;
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            // Implement
            return null;
        }
        #endregion Item
        */
    }
}
