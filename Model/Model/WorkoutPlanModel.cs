using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppModel.Model
{
    public class WorkoutPlanModel
    {
        public required string PlanName { get; set; }

        public required string UserId { get; set; }

        public required string StartTime { get; set; }

        public required string EndTime { get; set; }

        public required float Distance { get; set; }

        public float? CaloriesBurnt { get; set; }

        public int? Step { get; set; }
    }
}
