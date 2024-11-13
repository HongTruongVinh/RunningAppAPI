using RunningAppModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.IServices
{
    public interface IHomeService
    {
        Task<HomeModel> GetDataForHome(string? UserId);
    }
}
