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
        private static readonly string _collectionName = "WorkoutPlans";
        public WorkoutPlanRepository(IMongoDatabase database) : base(database, _collectionName)
        {

        }
    }
}
