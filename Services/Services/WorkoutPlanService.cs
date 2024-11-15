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

        public async Task<IEnumerable<WorkoutPlanModel>> GetByUserId(string userId)
        {
            var entities = await _workoutPlanRepository.GetWorkoutPlansByUserId(userId);

            var returnValue = new List<WorkoutPlanModel>();

            foreach (var e in entities)
            {
                var model = new WorkoutPlanModel
                {
                    WorkoutPlanId = e.Id,
                    UserId = e.UserId,
                    PlanName = e.PlanName,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    CaloriesBurnt = e.CaloriesBurnt,
                    Distance = e.Distance,
                    Step = e.Step
                };

                returnValue.Add(model);
            }

            return returnValue;
        }
        public async Task<WorkoutPlanModel> GetById(string id)
        {
            var e = await _workoutPlanRepository.GetByIdAsync(id);

            var returnValue = new WorkoutPlanModel
            {
                WorkoutPlanId = e.Id,
                UserId = e.UserId,
                PlanName = e.PlanName,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                CaloriesBurnt = e.CaloriesBurnt,
                Distance = e.Distance,
                Step = e.Step
            };

            return returnValue;
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
                    CaloriesBurnt = 95,
                    Step = 700,
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
