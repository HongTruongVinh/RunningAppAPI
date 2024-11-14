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
        Task<List<RouteModel>> GetAllRoutesByUserId(string userId);
        Task<RouteModel> GetRouteById(string id);
        Task<bool> AddNewRote(RouteModel model);
    }
}
