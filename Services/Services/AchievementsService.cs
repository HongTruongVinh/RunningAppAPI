using RunningAppData.Entities;
using RunningAppData.IRepository;
using RunningAppModel.Model;
using RunningAppServices.CommonFunction;
using RunningAppServices.IServices;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.Services
{
    public class AchievementsService : IAchievementsService
    {
        private readonly IAchievementsRepository _achievementsRepository;

        public AchievementsService(IAchievementsRepository achievementsRepository)
        {
            _achievementsRepository = achievementsRepository;
        }

        public async Task<List<AchievementsModel>> GetByUserId(string userId)
        {
            List<AchievementsModel> returnValue = new List<AchievementsModel>();

            var Entities = await _achievementsRepository.GetAchievementsByUserId(userId);

            foreach (var entity in Entities)
            {
                AchievementsModel returnRoute = new AchievementsModel()
                {
                    AchievementsId = entity.AchievementsId,
                    UserId = entity.UserId,
                    Name = entity.Name,
                    Description = entity.Description,
                    EarnedDate = entity.EarnedDate
                };
                returnValue.Add(returnRoute);
            }

            return returnValue;
        }

        public async Task<AchievementsModel> GetById(string id)
        {
            var entity = await _achievementsRepository.GetByIdAsync(id);

            AchievementsModel returnRoute = new AchievementsModel()
            {
                AchievementsId = entity.AchievementsId,
                UserId = entity.UserId,
                Name = entity.Name,
                Description = entity.Description,
                EarnedDate = entity.EarnedDate
            };

            return returnRoute;
        }

        public async Task<string> AddNew(AchievementsModel model)
        {
            bool success = false;

            Achievements dataInsert = new Achievements
            {
                AchievementsId = model.AchievementsId,
                UserId = model.UserId,
                Name = model.Name,
                Description = model.Description,
                EarnedDate = model.EarnedDate,
                Status = 1,
                CreateTime = TimeZoneService.Now().ToString()
            };

            success = await _achievementsRepository.AddAsync(dataInsert);

            var newEntity = await _achievementsRepository.GetByCreateTimeAsync(dataInsert.CreateTime);

            if (newEntity != null)
            {
                newEntity.AchievementsId = newEntity.Id;

                success = await _achievementsRepository.UpdateAsync(newEntity.Id ?? "", newEntity);
            }

            if (!success)
            {
                return "error";
            }
            else
            {
                return newEntity?.AchievementsId??"";
            }
        }
    }
}
