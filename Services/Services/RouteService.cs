using RunningAppData.Entities;
using RunningAppData.IRepository;
using RunningAppModel.Model;
using RunningAppServices.CommonFunction;
using RunningAppServices.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IRoutePointRepository _routePointRepository;

        public RouteService(IRouteRepository routeRepository, IRoutePointRepository routePointRepository) 
        {
            _routeRepository = routeRepository;
            _routePointRepository = routePointRepository;
        }

        public async Task<List<RouteModel>> GetByUserId(string userId)
        {
            List<RouteModel> returnValue = new List<RouteModel>();

            var routes = await _routeRepository.GetRoutesByUserId(userId);

            foreach (var route in routes)
            {
                RouteModel returnRoute = new RouteModel()
                {
                    RouteId = route.RouteId,
                    UserId = route.UserId,
                    RouteName = route.RouteName,
                    Distance = route.Distance,
                    CreateDate = route.CreateDate
                };
                returnValue.Add(returnRoute);
            }

            return returnValue;
        }

        public async Task<RouteModel> GetById(string routeId)
        {
            var entity = await _routeRepository.GetByIdAsync(routeId);

            IEnumerable<RoutePoint> routePointsEntities = await _routePointRepository.GetAllAsync();

            routePointsEntities = routePointsEntities.Where(x => x.RouteId == routeId);

            var returnRoutePoints = new List<RoutePointModel>();

            foreach (var routePoint in routePointsEntities)
            {
                RoutePointModel routePointModel = new RoutePointModel()
                {
                    PointId = routePoint.PointId,
                    RouteId = routePoint.RouteId,
                    Latitude = routePoint.Latitude,
                    Longitude = routePoint.Longitude,
                    TimeStamp = routePoint.TimeStamp
                };

                returnRoutePoints.Add(routePointModel);
            }

            RouteModel returnRoute = new RouteModel()
            {
                RouteId = entity.RouteId,
                UserId = entity.UserId,
                RouteName = entity.RouteName,
                Distance = entity.Distance,
                CreateDate = entity.CreateDate,
                RoutePoints = returnRoutePoints,
            };

            return returnRoute;
        }

        public async Task<string> AddNew(RouteModel model)
        {
            bool success = false;

            Route dataInsert = new Route
            {
                RouteId = model.RouteId,
                UserId = model.UserId,
                RouteName = model.RouteName,
                Distance = model.Distance,
                CreateDate = model.CreateDate,
                Status = 1,
                CreateTime = TimeZoneService.Now().ToString()
            };

            success = await _routeRepository.AddAsync(dataInsert);

            var newEntity = await _routeRepository.GetByCreateTimeAsync(dataInsert.CreateTime);

            if (newEntity != null)
            {
                newEntity.RouteId = newEntity.Id;

                success = await _routeRepository.UpdateAsync(newEntity.Id ?? "", newEntity);
            }

            if (!success)
            {
                return "error";
            }
            else
            {
                return newEntity?.RouteId??"";
            }
        }


    }
}
