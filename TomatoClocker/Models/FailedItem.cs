using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClocker.Models
{
    public class FailedItem
    {
        public int Id { get; set; }

        public DayCount DayCount { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string? PlanContent { get; set; }

        public string? DoContent { get; set; }

        public string? FailedReason { get; set; }

        public string? Remark { get; set; }

        public double ContinuousTime { get; set; }
    }
}
