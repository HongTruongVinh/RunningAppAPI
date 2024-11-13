using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Entities
{
    public class Goal : BaseEntity
    {
        [BsonElement("GoalId")]
        public string? GoalId { get; set; }

        [BsonElement("UserId")]
        public string? UserId { get; set; }

        [BsonElement("GoalType")]
        public string? GoalType { get; set;}

        [BsonElement("GoalValue")]
        public string? GoalValue { get; set; }

        [BsonElement("StartDate")]
        public string? StartDate { get; set; }

        [BsonElement("EndDate")]
        public string? EndDate { get; set; }

    }
}
