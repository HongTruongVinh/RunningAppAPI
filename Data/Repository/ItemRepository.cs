using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Repository
{
    public class ItemRepository
    {
        private readonly IMongoCollection<Item> _items;

        public ItemRepository(IMongoDatabase database)
        {
            _items = database.GetCollection<Item>("Items");
        }

        public async Task<List<Item>> GetAllAsync() =>
            await _items.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Item item) =>
            await _items.InsertOneAsync(item);

        public async Task<Item?> GetByIdAsync(string id) =>
            await _items.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, Item updatedItem) =>
            await _items.ReplaceOneAsync(x => x.Id == id, updatedItem);

        public async Task DeleteAsync(string id) =>
            await _items.DeleteOneAsync(x => x.Id == id);
    }

}
