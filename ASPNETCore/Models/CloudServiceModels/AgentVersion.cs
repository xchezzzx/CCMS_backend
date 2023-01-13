using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.CloudServiceModels
{
    public partial class AgentVersion
    {
        public int Id { get; set; }
        public string Version { get; set; } = null!;
        public DateTime ExpiresOn { get; set; }
        public string? Comment { get; set; }
    }
}
