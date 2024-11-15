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
        public required string PlanName { get; set; }

        [BsonElement("UserId")]
        public required string UserId { get; set; }

        [BsonElement("StartTime")]
        public required string StartTime { get; set; }

        [BsonElement("EndTime")]
        public required string EndTime { get; set; }

        [BsonElement("Distance")]
        public required float Distance { get; set; }

        [BsonElement("CaloriesBurnt")]
        public required float CaloriesBurnt { get; set; }

        [BsonElement("Step")]
        public required int Step { get; set; }

    }
}
