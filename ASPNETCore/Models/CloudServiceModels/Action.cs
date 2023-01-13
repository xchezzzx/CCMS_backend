using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.CloudServiceModels
{
    public partial class Action
    {
        public Action()
        {
            Task1s = new HashSet<Task1>();
        }

        public Guid Id { get; set; }
        public Guid? Syncgroupid { get; set; }
        public int Type { get; set; }
        public int State { get; set; }
        public DateTime? Creationtime { get; set; }
        public DateTime? Lastupdatetime { get; set; }

        public virtual ICollection<Task1> Task1s { get; set; }
    }
}
