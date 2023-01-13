using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.CloudServiceModels
{
    public partial class Schedule
    {
        public Schedule()
        {
            ScheduleTask1s = new HashSet<ScheduleTask1>();
        }

        public int ScheduleId { get; set; }
        public int FreqType { get; set; }
        public int FreqInterval { get; set; }

        public virtual ICollection<ScheduleTask1> ScheduleTask1s { get; set; }
    }
}
