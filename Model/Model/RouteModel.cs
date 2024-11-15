using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppModel.Model
{
    public class RouteModel
    {
        public string? RouteId { get; set; }

        public string? RouteName { get; set; }

        public string? UserId { get; set; }

        public float? Distance { get; set; }

        public string? CreateDate { get; set; }

        public IEnumerable<RoutePointModel>? RoutePoints { get; set; }
    }
}
