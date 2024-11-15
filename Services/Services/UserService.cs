using RunningAppData.Entities;
using RunningAppData.GenericRepository;
using RunningAppData.IRepository;
using RunningAppData.Repository;
using RunningAppModel.Model;
using RunningAppServices.CommonFunction;
using RunningAppServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RunningAppServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserInformationModel> GetByUsername(string username)
        {
            var entity = await _repository.GetUserByUsernameAsync(username);

            UserInformationModel returnValue = new UserInformationModel
            {
                UserId = entity.Id ?? "",
                Age = entity.Age,
                Weight = entity.Weight,
                Height = entity.Height,
                AvatarId = entity.AvatarId,
            };

            return returnValue;
        }

        public async Task<UserInformationModel> GetById(string id)
        {
            var entity = await _repository.GetByIdAsync(id);

            UserInformationModel returnValue = new UserInformationModel
            {
                UserId = entity.Id ?? "",
                Age = entity.Age,
                Weight = entity.Weight,
                Height = entity.Height,
                AvatarId = entity.AvatarId,
            };

            return returnValue;
        }

        public async Task<User> GetEntityById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> AddEntity(User entity)
        {
            var existUser = await _repository.GetUserByUsernameAsync(entity.Username);
            
            if (existUser == null)
            {
                User dataInsert = new User
                {
                    Username = entity.Username,
                    UserHash = entity.UserHash,
                    Age = entity.Age,
                    Weight = entity.Weight,
                    Height = entity.Height,
                    AvatarId = entity.AvatarId,
                    JoinDate = TimeZoneService.Now().ToString(),
                    Status = 1,
                    CreateTime = TimeZoneService.Now().ToString()
                };

                return await _repository.AddAsync(dataInsert);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AddNewUser(UserInformationModel inforModel, UserAccountModel accountModel)
        {
            bool isUsernameExit = string.IsNullOrEmpty(_repository.GetUserByUsername(accountModel.Username)?.Username);
            if (!isUsernameExit)
            {
                User dataInsert = new User
                {
                    Username = accountModel.Username,
                    UserHash = accountModel.UserHash,
                    Age = inforModel.Age,
                    Weight = inforModel.Weight,
                    Height = inforModel.Height,
                    AvatarId = inforModel.AvatarId,
                    JoinDate = TimeZoneService.Now().ToString(),
                    Status = 1,
                    CreateTime = TimeZoneService.Now().ToString()
                };

                await _repository.AddAsync(dataInsert);

                var newUser = _repository.GetUserByUsername(accountModel.Username);
                newUser.UserId = newUser.Id;
                await _repository.UpdateAsync(newUser.Id??"", newUser);

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserInformation(string id, UserInformationModel model)
        {
            var getData = await _repository.GetByIdAsync(id);

            getData.Age = model.Age;
            getData.Weight = model.Weight;
            getData.Height = model.Height;
            getData.AvatarId = model.AvatarId;

            return await _repository.UpdateAsync(id, getData);
        }

        public async Task<bool> DeleteEntity(string id)
        {
            var getData = await _repository.GetByIdAsync(id);

            getData.Status = -1;

            return await _repository.UpdateAsync(id, getData);
        }
    }
}
