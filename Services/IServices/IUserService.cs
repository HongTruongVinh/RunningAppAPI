using RunningAppData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.IServices
{
    public interface IUserService
    {
        Task<User> GetEntityById(string id);
        Task AddEntity(User entity);
    }
}
