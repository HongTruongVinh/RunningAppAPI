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
    public class AvatarRepository : GenericRepository<Avatar>, IAvatarRepository
    {
        private static readonly string _collectionName = "Avatars";
        public AvatarRepository(IMongoDatabase database) : base(database, _collectionName)
        {

        }
    }
}
