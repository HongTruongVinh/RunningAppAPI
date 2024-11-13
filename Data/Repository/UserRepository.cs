using MongoDB.Driver;
using RunningAppData.Entities;
using RunningAppData.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("Users");
        }

        public User GetUserByUsername(string username)
        {
            return _users.Find(x => x.Username == username).FirstOrDefault();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _users.Find(x => x.Username == username).FirstOrDefaultAsync();
        }




        public async Task InsertInitialUserAsync()
        {
            User newUser = new User()
            {
                Username = "1"
            };

            await _users.InsertOneAsync(newUser);
        }

    }
}
