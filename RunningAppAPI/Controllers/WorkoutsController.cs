using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunningAppModel.Model;
using RunningAppServices.IServices;

namespace RunningAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutPlanService _workoutPlanService;

        public WorkoutsController(IWorkoutPlanService userService)
        {
            _workoutPlanService = userService;
        }

        [HttpGet("{user_id}")]
        public async Task<IEnumerable<WorkoutPlanModel>> GetByUserId(string user_id)
        {
            var result = await _workoutPlanService.GetByUserId(user_id);
            return result;
        }

        [HttpGet("details/{workout_id}")]
        public async Task<WorkoutPlanModel> GetById(string workout_id)
        {
            var result = await _workoutPlanService.GetById(workout_id);
            return result;
        }

        [HttpPost("")]
        public async Task<bool> Create(WorkoutPlanModel workoutPlanModel)
        {
            var result = await _workoutPlanService.AddNewWorkoutPlan(workoutPlanModel);
            return result;
        }
    }
}
