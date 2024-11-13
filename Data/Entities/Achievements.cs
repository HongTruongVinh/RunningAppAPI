using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Entities
{
    public class Achievements : BaseEntity
    {
        [BsonElement("AchievementsId")]
        public string? AchievementsId { get; set; }

        [BsonElement("UserId")]
        public string? UserId { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("EarnedDate")]
        public string? EarnedDate { get; set; }
    }
}
