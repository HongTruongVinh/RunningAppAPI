using RunningAppModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.IServices
{
    public interface IGoalService
    {
        Task<List<GoalModel>> GetAllByUserId(string userId);
        Task<GoalModel> GetById(string id);
        Task<bool> AddNew(GoalModel model);
    }
}
