using Beise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beise.Services
{
    public class MockDataStore : IDataStore<Item2>
    {
        readonly List<Item2> items;

        public MockDataStore()
        {
            items = new List<Item2>()
            {
                new Item2 { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item2 { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item2 { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item2 { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item2 { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item2 { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item2 item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item2 item)
        {
            var oldItem = items.Where((Item2 arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item2 arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item2> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item2>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}