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
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository routeRepository)
        {
            _goalRepository = routeRepository;
        }

        public async Task<List<GoalModel>> GetAllByUserId(string userId)
        {
            List<GoalModel> returnValue = new List<GoalModel>();

            var Entities = await _goalRepository.GetGoalsByUserId(userId);

            foreach (var entity in Entities)
            {
                GoalModel returnRoute = new GoalModel()
                {
                    GoalId = entity.GoalId,
                    UserId = entity.UserId,
                    GoalType = entity.GoalType,
                    GoalValue = entity.GoalValue,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate
                };
                returnValue.Add(returnRoute);
            }

            return returnValue;
        }

        public async Task<GoalModel> GetById(string id)
        {
            var entity = await _goalRepository.GetByIdAsync(id);

            GoalModel returnRoute = new GoalModel()
            {
                GoalId = entity.GoalId,
                UserId = entity.UserId,
                GoalType = entity.GoalType,
                GoalValue = entity.GoalValue,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };

            return returnRoute;
        }

        public async Task<string> AddNew(GoalModel model)
        {
            bool success = false;

            Goal dataInsert = new Goal
            {
                GoalId = model.GoalId,
                UserId = model.UserId,
                GoalType = model.GoalType,
                GoalValue = model.GoalValue,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Status = 1,
                CreateTime = TimeZoneService.Now().ToString()
            };

            success = await _goalRepository.AddAsync(dataInsert);

            var newEntity = await _goalRepository.GetByCreateTimeAsync(dataInsert.CreateTime);

            if (newEntity != null)
            {
                newEntity.GoalId = newEntity.Id;

                success = await _goalRepository.UpdateAsync(newEntity.Id ?? "", newEntity);
            }

            if (!success)
            {
                return "error";
            }
            else
            {
                return newEntity?.GoalId ?? "";
            }
        }

        public async Task<string> Update(GoalModel model)
        {
            bool success = false;

            var entity = await _goalRepository.GetByIdAsync(model.GoalId ?? "");

            if (entity != null)
            {
                Goal dataInsert = new Goal
                {
                    GoalId = model.GoalId,
                    UserId = model.UserId,
                    GoalType = model.GoalType,
                    GoalValue = model.GoalValue,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Status = 1,
                    CreateTime = entity.CreateTime
                };

                success = await _goalRepository.UpdateAsync(entity.Id ?? "", dataInsert);
            }

            if (!success)
            {
                return "error";
            }
            else
            {
                return "updated";
            }
        }
    }
}
