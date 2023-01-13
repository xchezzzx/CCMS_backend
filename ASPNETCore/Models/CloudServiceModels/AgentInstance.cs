using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.CloudServiceModels
{
    public partial class AgentInstance
    {
        public Guid Id { get; set; }
        public Guid Agentid { get; set; }
        public DateTime? Lastalivetime { get; set; }
        public string Version { get; set; } = null!;

        public virtual Agent Agent { get; set; } = null!;
    }
}
