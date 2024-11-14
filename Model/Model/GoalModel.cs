using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppModel.Model
{
    public class GoalModel
    {
        public string? GoalId { get; set; }

        public string? UserId { get; set; }

        public string? GoalType { get; set; }

        public string? GoalValue { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }
    }
}
