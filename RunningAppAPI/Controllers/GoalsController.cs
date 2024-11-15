using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunningAppModel.Model;
using RunningAppServices.IServices;
using RunningAppServices.Services;

namespace RunningAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalsController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet("{user_id}")]
        public async Task<IEnumerable<GoalModel>> GetByUserId(string user_id)
        {
            var result = await _goalService.GetAllByUserId(user_id);
            return result;
        }

        [HttpPost]
        public async Task<string> Create(GoalModel model)
        {
            var result = await _goalService.AddNew(model);
            return result;
        }

        [HttpPut]
        public async Task<string> Update(GoalModel model)
        {
            var result = await _goalService.Update(model);
            return result;
        }
    }
}
