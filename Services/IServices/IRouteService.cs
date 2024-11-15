using RunningAppModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.IServices
{
    public interface IRouteService
    {
        Task<List<RouteModel>> GetByUserId(string userId);
        Task<RouteModel> GetById(string id);
        Task<string> AddNew(RouteModel model);
    }
}
