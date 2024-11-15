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
        Task<List<AchievementsModel>> GetByUserId(string userId);
        Task<AchievementsModel> GetById(string id);
        Task<string> AddNew(AchievementsModel model);
    }
}
