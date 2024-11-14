using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppModel.Model
{
    public class UserAccountModel
    {
        public required string Username { get; set; }

        public string? UserHash { get; set; }
    }
}
