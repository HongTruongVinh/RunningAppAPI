using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunningAppModel.Model;
using RunningAppServices.IServices;

namespace RunningAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IRoutePointService _routePointService;

        public RoutesController(IRouteService userService, IRoutePointService routePointService)
        {
            _routeService = userService;
            _routePointService = routePointService;
        }

        [HttpGet("{route_id}")]
        public async Task<RouteModel> GetById(string route_id)
        {
            var result = await _routeService.GetById(route_id);
            return result;
        }

        [HttpPost("")]
        public async Task<string> Create(RouteModel model)
        {
            var result = await _routeService.AddNew(model);
            return result;
        }

        [HttpGet("{route_id}/points")]
        public async Task<bool> GetPointsByRouteId(string route_id, RoutePointModel model)
        {
            if (String.IsNullOrEmpty(model.RouteId))
            {
                model.RouteId = route_id;
            }
            var result = await _routePointService.AddNew(model);
            return result;
        }


    }
}
