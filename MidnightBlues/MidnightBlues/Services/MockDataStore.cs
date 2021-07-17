using MidnightBlues.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidnightBlues.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), AlbumName = "It Has Begun", Artist = "STARSET", Description="An Alternative Rock song by an american band." },
                new Item { Id = Guid.NewGuid().ToString(), AlbumName = "Shining Step", Artist = "Interlunium", Description="A Pop song by an american artist." },
                new Item { Id = Guid.NewGuid().ToString(), AlbumName = "No Aguanto", Artist = "Neto Peña, Nanpa Básico", Description="A Hip-Hop song by a mexican artist." },
                new Item { Id = Guid.NewGuid().ToString(), AlbumName = "Puro Talento", Artist = "Miranda!", Description="A Pop song by an argetinian band." },
                new Item { Id = Guid.NewGuid().ToString(), AlbumName = "carmen", Artist = "Stromae", Description="A Synthpop song by a belgian artist." },
                new Item { Id = Guid.NewGuid().ToString(), AlbumName = "Du", Artist = "Nadja Evelina", Description="A Pop song by a swedish artist." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}