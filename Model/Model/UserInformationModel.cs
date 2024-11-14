using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppModel.Model
{
    public class UserInformationModel
    {
        public required string UserId { get; set; }

        public int? Age { get; set; }

        public float? Weight { get; set; }

        public float? Height { get; set; }

        public string? AvatarId { get; set; }
    }
}
