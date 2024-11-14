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
        private static readonly string _collectionName = "Routes";
        public RouteRepository(IMongoDatabase database) : base(database, _collectionName)
        {

        }
    }
}
