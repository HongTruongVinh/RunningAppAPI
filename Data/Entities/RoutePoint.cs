
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Entities
{
    public class RoutePoint : BaseEntity
    {
        [BsonElement("PointId")]
        public string? PointId { get; set; }

        [BsonElement("RouteId")]
        public string? RouteId { get; set; }

        [BsonElement("Latitude")]
        public string? Latitude { get; set;}

        [BsonElement("Longitude")]
        public string? Longitude { get; set;}

        [BsonElement("TimeStamp")]
        public string? TimeStamp { get; set; }
    }
}
