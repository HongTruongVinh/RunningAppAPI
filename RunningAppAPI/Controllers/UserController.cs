using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunningAppData.Entities;
using RunningAppModel.Model;
using RunningAppServices.IServices;

namespace RunningAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUserByUsername")]
        public async Task<User> Get(string username)
        {
            var result = await _userService.GetEntityByUsername(username);
            return result;
        }

        [HttpPatch(Name = "UpdateUser")]
        public async Task<bool> Update(UserInformationModel userInformationModel)
        {
            var result = await _userService.UpdateUserInformation(userInformationModel.UserId, userInformationModel);
            return result;
        }

        //[HttpGet(Name = "GetAllUser")]
        //public async Task<IEnumerable<User>> GetAllUser()
        //{
        //    var result = await _userService.GetAllUser();
        //    return result;
        //}
    }
}
