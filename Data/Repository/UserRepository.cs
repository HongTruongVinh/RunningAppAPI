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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMongoCollection<User> _collection;
        private static readonly string _collectionName = "Users";

        public UserRepository(IMongoDatabase database) : base(database, _collectionName)
        {
            _collection = database.GetCollection<User>(_collectionName);
        }

        public User GetUserByUsername(string username)
        {
            return _collection.Find(x => x.Username == username).FirstOrDefault();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _collection.Find(x => x.Username == username).FirstOrDefaultAsync();
        }
    }
}
