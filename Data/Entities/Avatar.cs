using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Entities
{
    public class Avatar : BaseEntity
    {
        [BsonElement("AvatarId")]
        public string? AvatarId { get; set; }

        [BsonElement("AvatarName")]
        public string? AvatarName { get; set; }

        [BsonElement("TopColor")]
        public string? TopColor { get; set; }

        [BsonElement("MidColor")]
        public string? MidColor { get; set; }

        [BsonElement("BottomColor")]
        public string? BottomColor { get; set; }

        [BsonElement("Price")]
        public int? Price { get; set; }

    }
}
