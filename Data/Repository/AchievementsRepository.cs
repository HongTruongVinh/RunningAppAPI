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
    public class AchievementsRepository : GenericRepository<Achievements>, IAchievementsRepository
    {
        private readonly IMongoCollection<Achievements> _collection;
        private static readonly string _collectionName = "Achievements";
        public AchievementsRepository(IMongoDatabase database) : base(database, _collectionName)
        {
            _collection = database.GetCollection<Achievements>(_collectionName);
        }

        public async Task<IEnumerable<Achievements>> GetAchievementsByUserId(string userId)
        {
            // Tạo bộ lọc để tìm các item có UserId = 1
            var filter = Builders<Achievements>.Filter.Eq("UserId", userId);

            // Thực hiện tìm kiếm và trả về danh sách các item thỏa mãn bộ lọc
            var result = await _collection.Find(filter).ToListAsync();

            return result;
        }
    }
}
