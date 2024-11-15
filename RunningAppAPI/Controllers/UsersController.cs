using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunningAppData.Entities;
using RunningAppModel.Model;
using RunningAppServices.IServices;

namespace RunningAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{user_id}")]
        public async Task<UserInformationModel> Get(string user_id)
        {
            var result = await _userService.GetById(user_id);
            return result;
        }

        [HttpPut]
        public async Task<bool> Update(UserInformationModel userInformationModel)
        {
            var result = await _userService.UpdateUserInformation(userInformationModel.UserId, userInformationModel);
            return result;
        }

        [HttpGet("GetAllUser")]
        public async Task<IEnumerable<User>> GetAllUser()
        {
            var result = await _userService.GetAllUser();
            return result;
        }
    }
}
