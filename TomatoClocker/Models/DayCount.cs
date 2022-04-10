using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoClocker.Models
{
    public class DayCount
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }

        public List<FailedItem> FailedItems { get; set; } = new List<FailedItem>();

        public List<SuccessItem> SuccessItems { get; set; } = new List<SuccessItem>();
    }
}
