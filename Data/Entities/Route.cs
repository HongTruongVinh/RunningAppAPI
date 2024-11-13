using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Entities
{
    public class Route : BaseEntity
    {
        [BsonElement("RouteId")]
        public string? RouteId { get; set; }

        [BsonElement("RouteName")]
        public string? RouteName { get; set; }

        [BsonElement("UserId")]
        public string? UserId { get; set; }

        [BsonElement("Distance")]
        public float? Distance { get; set; }

        [BsonElement("CreateDate")]
        public string? CreateDate { get; set; }

    }
}
