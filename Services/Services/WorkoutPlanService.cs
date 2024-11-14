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
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly IWorkoutPlanRepository _workoutPlanRepository;
        private readonly IUserRepository _userRepository;

        public WorkoutPlanService(IWorkoutPlanRepository workoutPlanRepository, IUserRepository userRepository)
        {
            _workoutPlanRepository = workoutPlanRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<WorkoutPlan>> GetAllWorkoutPlansByUserId(string userId)
        {
            return await _workoutPlanRepository.GetWorkoutPlansByUserId(userId);
        }
        public async Task<WorkoutPlan> GetWorkoutPlanById(string id)
        {
            return await _workoutPlanRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddNewWorkoutPlan(WorkoutPlanModel model)
        {
            var existUser = await _userRepository.GetByIdAsync(model.UserId);

            if (existUser != null)
            {

                WorkoutPlan dataInsert = new WorkoutPlan
                {
                    UserId = model.UserId,
                    PlanName = model.PlanName,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    Distance = model.Distance,
                    Status = 1,
                    CreateTime = TimeZoneService.Now().ToString(),
                };

                await _workoutPlanRepository.AddAsync(dataInsert);

                var userWorkoutPlans = await _workoutPlanRepository.GetWorkoutPlansByUserId(model.UserId);

                var newWorkoutPlan = userWorkoutPlans.Where(x => x.CreateTime == dataInsert.CreateTime).FirstOrDefault();

                if (newWorkoutPlan != null)
                {
                    newWorkoutPlan.WorkoutPlanId = newWorkoutPlan.Id;

                    await _workoutPlanRepository.UpdateAsync(newWorkoutPlan.WorkoutPlanId??"", newWorkoutPlan);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteWorkoutPlan(string id)
        {
            return await _workoutPlanRepository.DeleteAsync(id);
        }

    }
}
