using MongoDB.Bson;
using MongoDB.Driver;
using RunningAppData.Entities;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(string id, T entity)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
                await _collection.ReplaceOneAsync(filter, entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
                await _collection.DeleteOneAsync(filter);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
