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
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        private readonly IMongoCollection<Route> _collection;
        private static readonly string _collectionName = "Routes";
        public RouteRepository(IMongoDatabase database) : base(database, _collectionName)
        {
            _collection = database.GetCollection<Route>(_collectionName);
        }

        public async Task<IEnumerable<Route>> GetRoutesByUserId(string userId)
        {
            var filter = Builders<Route>.Filter.Eq("UserId", userId);
            var result = await _collection.Find(filter).ToListAsync();

            return result;
        }
    }
}
