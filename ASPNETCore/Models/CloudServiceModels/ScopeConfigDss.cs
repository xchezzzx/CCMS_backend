using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.CloudServiceModels
{
    public partial class ScopeConfigDss
    {
        public Guid ConfigId { get; set; }
        public string ConfigData { get; set; } = null!;
        public string? ScopeStatus { get; set; }
    }
}
