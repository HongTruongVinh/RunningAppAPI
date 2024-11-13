using RunningAppData.Entities;
using RunningAppData.GenericRepository;
using RunningAppServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RunningAppServices.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;

        public UserService(IGenericRepositoryFactory factory)
        {
            _repository = factory.Create<User>("Users");
        }

        public async Task<User> GetEntityById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddEntity(User entity)
        {
            await _repository.AddAsync(entity);
        }


    }
}
