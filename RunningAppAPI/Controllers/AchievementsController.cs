using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunningAppModel.Model;
using RunningAppServices.IServices;

namespace RunningAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly IAchievementsService _achievementsService;

        public AchievementsController(IAchievementsService achievementsService)
        {
            _achievementsService = achievementsService;
        }

        [HttpGet("{user_id}")]
        public async Task<IEnumerable<AchievementsModel>> GetByUserId(string user_id)
        {
            var result = await _achievementsService.GetByUserId(user_id);
            return result;
        }

        [HttpPost]
        public async Task<string> Create(AchievementsModel model)
        {
            var result = await _achievementsService.AddNew(model);
            return result;
        }
    }
}
