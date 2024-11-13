using RunningAppData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.IRepository
{
    public interface IRouteRepository
    {
        Route GetById(string id);
        Task<Route> GetByIdAsync(string id);
    }
}
