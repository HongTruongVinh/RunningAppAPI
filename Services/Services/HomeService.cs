using RunningAppModel.Model;
using RunningAppServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.Services
{
    public class HomeService : IHomeService
    {
        public async Task<HomeModel> GetDataForHome(string? UserId)
        {
            HomeModel returnValue = new HomeModel();

            return  returnValue;
        }
    }
}
