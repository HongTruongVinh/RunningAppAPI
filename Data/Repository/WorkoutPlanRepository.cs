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
    public class WorkoutPlanRepository : GenericRepository<WorkoutPlan>, IWorkoutPlanRepository
    {
        private readonly IMongoCollection<WorkoutPlan> _collection;
        private static readonly string _collectionName = "WorkoutPlans";
        public WorkoutPlanRepository(IMongoDatabase database) : base(database, _collectionName)
        {
            _collection = database.GetCollection<WorkoutPlan>(_collectionName);
        }
        public async Task<IEnumerable<WorkoutPlan>> GetWorkoutPlansByUserId(string userId)
        {
            // Tạo bộ lọc để tìm các item có UserId = 1
            var filter = Builders<WorkoutPlan>.Filter.Eq("UserId", userId);

            // Thực hiện tìm kiếm và trả về danh sách các item thỏa mãn bộ lọc
            var result = await _collection.Find(filter).ToListAsync();

            return result;
        }
    }
}
