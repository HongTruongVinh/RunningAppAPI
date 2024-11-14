using MongoDB.Driver;
using RunningAppData.Entities;
using RunningAppData.GenericRepository;
using RunningAppData.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Repository
{
    public class GoalRepository : GenericRepository<Goal>, IGoalRepository
    {
        private readonly IMongoCollection<Goal> _collection;
        private static readonly string _collectionName = "Goals";
        public GoalRepository(IMongoDatabase database) : base(database, _collectionName)
        {
            _collection = database.GetCollection<Goal>(_collectionName);
        }

        public async Task<IEnumerable<Goal>> GetGoalsByUserId(string userId)
        {
            var filter = Builders<Goal>.Filter.Eq("UserId", userId);
            var result = await _collection.Find(filter).ToListAsync();

            return result;
        }
    }
}
