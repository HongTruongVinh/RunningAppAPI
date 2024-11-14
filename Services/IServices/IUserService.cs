using RunningAppData.Entities;
using RunningAppModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetEntityByUsername(string username);
        Task<User> GetEntityById(string id);
        Task<bool> AddEntity(User entity);
        Task<bool> AddNewUser(UserInformationModel inforModel, UserAccountModel accountModel);
        Task<bool> UpdateUserInformation(string id, UserInformationModel model);
        Task<bool> DeleteEntity(string id);
    }
}
