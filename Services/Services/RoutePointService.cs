using RunningAppData.Entities;
using RunningAppData.IRepository;
using RunningAppModel.Model;
using RunningAppServices.CommonFunction;
using RunningAppServices.IServices;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.Services
{
    public class RoutePointService : IRoutePointService
    {
        private readonly IRoutePointRepository _routePointRepository;

        public RoutePointService(IRoutePointRepository routePointRepository)
        {
            _routePointRepository = routePointRepository;
        }

        public async Task<List<RoutePointModel>> GetAllByRouteId(string routeId)
        {
            List<RoutePointModel> returnValue = new List<RoutePointModel>();

            var Entities = await _routePointRepository.GetAllAsync();

            Entities = Entities.Where(x => x.RouteId == routeId).ToList();

            foreach (var entity in Entities)
            {
                RoutePointModel returnRoute = new RoutePointModel()
                {
                    PointId = entity.PointId,
                    RouteId = entity.RouteId,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                    TimeStamp = entity.TimeStamp
                };
                returnValue.Add(returnRoute);
            }

            return returnValue;
        }

        public async Task<RoutePointModel> GetById(string id)
        {
            var entity = await _routePointRepository.GetByIdAsync(id);

            RoutePointModel returnRoute = new RoutePointModel()
            {
                PointId = entity.PointId,
                RouteId = entity.RouteId,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                TimeStamp = entity.TimeStamp
            };

            return returnRoute;
        }

        public async Task<bool> AddNew(RoutePointModel model)
        {
            bool success = false;

            RoutePoint dataInsert = new RoutePoint
            {
                PointId = model.PointId,
                RouteId = model.RouteId,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                TimeStamp = model.TimeStamp,
                Status = 1,
                CreateTime = TimeZoneService.Now().ToString()
            };

            success = await _routePointRepository.AddAsync(dataInsert);

            var newEntity = await _routePointRepository.GetByCreateTimeAsync(dataInsert.CreateTime);

            if (newEntity != null)
            {
                newEntity.RouteId = newEntity.Id;

                success = await _routePointRepository.UpdateAsync(newEntity.Id ?? "", newEntity);
            }

            return success;
        }
    }
}
