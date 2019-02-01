using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week2.Models;
using Week2.ViewModels;

namespace Week2.Services
{
    public sealed class MockDataStore : IDataStore
    {

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static MockDataStore _instance;

        public static MockDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockDataStore();
                }
                return _instance;
            }
        }

        private List<Item> _itemDataset = new List<Item>();
        private List<Character> _CharacterDataset = new List<Character>();
        //private List<Monster> _monsterDataset = new List<Monster>();
        //private List<Score> _scoreDataset = new List<Score>();

        private MockDataStore()
        {
            InitilizeSeedData();
        }

        private void InitilizeSeedData()
        {

            // Implement

            // Load Items.
            string s1 = "Consumable Item. Easily found from Monsters, Wet Grass provides a rebuffs of 20% max health. " +
                "It looks like some other type of grass, but we promise you it's just totally coincidental. ";
            string s2 = "Consumable Item. This magical item will help you revitalize your Rabbit. " +
                "It tastes so good and organic that your Rabbit will be as healthy as new.";
            string s3 = "Wearable Item. This shield is commonly found by killing monsters. " +
                "It's just a basic few. It provide some protection, but its weird shape hinder its protecting ability.";
            string s4 = "Wearable Item. This treasure item is only dropped by a few selected Monster, " +
                "but its immense power is worth every struggle to find it.";
            string s5 = "Consumable Item. It increases your Wisdom, which doesn't do much for now. " +
                "Feed it to your rabbit anyway, what if it increases good luck.";
            _itemDataset.Add(new Item("Wet Grass", s1,
                "https://i.imgur.com/OyYLK0g.png", 4, AttributeEnum.CurrentHealth));

            _itemDataset.Add(new Item("Fresh Carrot", s2,
                "https://i.imgur.com/AyjmZVS.png", 15, AttributeEnum.CurrentHealth));

            _itemDataset.Add(new Item("Wet Grass", s1,
                "https://i.imgur.com/OyYLK0g.png", 4, AttributeEnum.CurrentHealth));
            _itemDataset.Add(new Item("Rope of Vengeance", s4,
                "https://i.imgur.com/9536yGE.png", 3, AttributeEnum.Strength));
            _itemDataset.Add(new Item("Magical Dew", s5,
                "https://i.imgur.com/8XCRPIG.png", 2, AttributeEnum.Wisdom));

            // Implement Character

            _CharacterDataset.Add(new Character("Hazel", "Hazel-rah", 5,2, 1000,
                "https://i.imgur.com/0rggUZ7.png", true));
            _CharacterDataset.Add(new Character("BigWit", "Thlayli", 6, 3, 1010,
                "https://i.imgur.com/0uaVKml.jpg", true));
            _CharacterDataset.Add(new Character("Clover", "The hutch rabbit", 5, 2, 1000,
                "https://i.imgur.com/qOzdUBt.png", true));
            _CharacterDataset.Add(new Character("Hyzenthlay", "The fearless female leader", 6, 3, 1010,
                "https://i.imgur.com/kIH4UtV.jpg", true));
            //_CharacterDataset.Add(new Character("Doug", "Unknown", 20, 3, 10000,
              //  "https://i.imgur.com/gkCDnJG.png", true));

            // Implement Monsters

            // Implement Scores
        }

        private void CreateTables()
        {
            // Do nothing...
        }

        // Delete the Datbase Tables by dropping them
        public void DeleteTables()
        {
            // Implement
        }

        // Tells the View Models to update themselves.
        private void NotifyViewModelsOfDataChange()
        {
            ItemsViewModel.Instance.SetNeedsRefresh(true);
            // Implement Monsters

            // Implement Characters 
            CharactersViewModel.Instance.SetNeedsRefresh(true);
            // Implement Scores
        }

        public void InitializeDatabaseNewTables()
        {
            DeleteTables();

            // make them again
            CreateTables();

            // Populate them
            InitilizeSeedData();

            // Tell View Models they need to refresh
            NotifyViewModelsOfDataChange();
        }

        #region Item
        // Item
        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {

            // Check to see if the item exist
            var oldData = await GetAsync_Item(data.ID);
            if (oldData == null)
            {
                _itemDataset.Add(data);
                return true;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Item(data);
            if (UpdateResult)
            {
                await AddAsync_Item(data);
                return true;
            }

            return false;
        }

        public async Task<bool> AddAsync_Item(Item data)
        {
            _itemDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.ID == data.ID);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.ID == data.ID);
            _itemDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            return await Task.FromResult(_itemDataset.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            return await Task.FromResult(_itemDataset);
        }

        #endregion Item

        #region Character
        //// Character
        public async Task<bool> AddAsync_Character(Character data)
        {
            _CharacterDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Character(Character data)
        {
            var myData = _CharacterDataset.FirstOrDefault(arg => arg.ID == data.ID);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Character(Character data)
        {
            var myData = _CharacterDataset.FirstOrDefault(arg => arg.ID == data.ID);
            _CharacterDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Character> GetAsync_Character(string id)
        {
            return await Task.FromResult(_CharacterDataset.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
            return await Task.FromResult(_CharacterDataset);
        }
        public async Task<bool> InsertUpdateAsync_Character(Character data)
        {

            // Check to see if the Character exist
            var oldData = await GetAsync_Character(data.ID);
            if (oldData == null)
            {
                _CharacterDataset.Add(data);
                return true;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Character(data);
            if (UpdateResult)
            {
                await AddAsync_Character(data);
                return true;
            }

            return false;
        }

        #endregion Character

        #region Monster
        ////Monster
        //public async Task<bool> AddAsync_Monster(Monster data)
        //{
        //    // Implement
        //    return false;
        //}

        //public async Task<bool> UpdateAsync_Monster(Monster data)
        //{
        //    // Implement
        //    return false;
        //}

        //public async Task<bool> DeleteAsync_Monster(Monster data)
        //{
        //    // Implement
        //    return false;
        //}

        //public async Task<Monster> GetAsync_Monster(string id)
        //{
        //    // Implement
        //    return null;
        //}

        //public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        //{
        //    // Implement
        //    return null;
        //}

        #endregion Monster

        #region Score
        //// Score
        //public async Task<bool> AddAsync_Score(Score data)
        //{
        //    // Implement
        //    return false;
        //}

        //public async Task<bool> UpdateAsync_Score(Score data)
        //{
        //    // Implement
        //    return false;
        //}

        //public async Task<bool> DeleteAsync_Score(Score data)
        //{
        //    // Implement
        //    return false;
        //}

        //public async Task<Score> GetAsync_Score(string id)
        //{
        //    // Implement
        //    return null;
        //}

        //public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        //{
        //    // Implement
        //    return null;
        //}
        #endregion Score
    }
}