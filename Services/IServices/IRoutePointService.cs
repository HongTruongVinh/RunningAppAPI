using RunningAppModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.IServices
{
    public interface IRoutePointService
    {
        Task<List<RoutePointModel>> GetAllByRouteId(string routeId);
        Task<RoutePointModel> GetById(string id);
        Task<bool> AddNew(RoutePointModel model);
    }
}
