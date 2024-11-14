using RunningAppModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.IServices
{
    public interface IAchievementsService
    {
        Task<List<AchievementsModel>> GetAllAchievementsByUserId(string userId);
        Task<AchievementsModel> GetRouteById(string id);
        Task<bool> AddNewRote(AchievementsModel model);
    }
}
