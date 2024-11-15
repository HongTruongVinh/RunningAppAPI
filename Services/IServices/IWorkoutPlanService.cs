using RunningAppData.Entities;
using RunningAppModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.IServices
{
    public interface IWorkoutPlanService
    {
        Task<IEnumerable<WorkoutPlanModel>> GetByUserId(string userId);
        Task<WorkoutPlanModel> GetById(string id);
        Task<bool> AddNewWorkoutPlan(WorkoutPlanModel model);
        Task<bool> DeleteWorkoutPlan(string id);
    }
}
