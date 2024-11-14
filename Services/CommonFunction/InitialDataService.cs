using RunningAppData.Entities;
using RunningAppServices.IServices;
using RunningAppServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.CommonFunction
{
    public class InitialDataService
    {
        IUserService _userService;

        public InitialDataService(IUserService userService)
        {
            _userService = userService;
        }

        public bool InitData()
        {
            try
            {
                User user1 = new User
                {
                    Username = "1",
                    UserHash = "UserHash",
                    Age = 22,
                    Weight = 54,
                    Height = 167,
                    AvatarId = "AvatarId",
                    JoinDate = TimeZoneService.Now().ToString(),
                    Status = 1,
                    CreateTime = TimeZoneService.Now().ToString()
                };
                _userService.AddEntity(user1);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
