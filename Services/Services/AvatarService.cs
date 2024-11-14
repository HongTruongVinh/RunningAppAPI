using RunningAppData.Entities;
using RunningAppData.IRepository;
using RunningAppModel.Model;
using RunningAppServices.CommonFunction;
using RunningAppServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.Services
{
    public class AvatarService : IAvatarService
    {
        private readonly IAvatarRepository _repository;

        public AvatarService(IAvatarRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Avatar>> GetAllAvatar()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> AddNewAvatar(AvatarModel model)
        {
            bool success = false;

            Avatar dataInsert = new Avatar
            {
                AvatarName = model.AvatarName,
                TopColor = model.TopColor,
                MidColor = model.MidColor,
                BottomColor = model.BottomColor,
                Price = model.Price,
                Status = 1,
                CreateTime = TimeZoneService.Now().ToString()
            };

            success = await _repository.AddAsync(dataInsert);

            var newAvatar = await _repository.GetByCreateTimeAsync(dataInsert.CreateTime);

            if (newAvatar != null)
            {
                newAvatar.AvatarId = dataInsert.Id;

                success = await _repository.UpdateAsync(newAvatar.Id??"", newAvatar);
            }

            return success;
        }
    }
}
