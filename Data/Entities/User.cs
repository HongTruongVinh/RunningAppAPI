using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.Entities
{
    public class User : BaseEntity
    {
        [BsonElement("UserId")]
        public string? UserId { get; set; }

        [BsonElement("Username")]
        public required string Username { get; set; }

        [BsonElement("UserHash")]
        public string? UserHash { get; set; }

        [BsonElement("Age")]
        public int? Age { get; set; }

        [BsonElement("Weight")]
        public float? Weight { get; set; }

        [BsonElement("Height")]
        public float? Height { get; set; }

        [BsonElement("JoinDate")]
        public string? JoinDate { get; set; }

        [BsonElement("AvatarId")]
        public string? AvatarId { get; set; }

    }
}
