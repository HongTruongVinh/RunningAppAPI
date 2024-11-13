using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Entities
{
    public class WorkoutPlan : BaseEntity
    {
        [BsonElement("WorkoutPlanId")]
        public string? WorkoutPlanId { get; set; }

        [BsonElement("PlanName")]
        public string? PlanName { get; set; }

        [BsonElement("UserId")]
        public string? UserId { get; set; }

        [BsonElement("StartTime")]
        public string? StartTime { get; set; }

        [BsonElement("EndTime")]
        public string? EndTime { get; set; }

        [BsonElement("Distance")]
        public float? Distance { get; set; }

        [BsonElement("CaloriesBurnt")]
        public float? CaloriesBurnt { get; set; }

        [BsonElement("Step")]
        public int? Step { get; set; }

    }
}
