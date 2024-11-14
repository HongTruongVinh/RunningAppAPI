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
        private static readonly string _collectionName = "Goals";
        public GoalRepository(IMongoDatabase database) : base(database, _collectionName)
        {

        }
    }
}
