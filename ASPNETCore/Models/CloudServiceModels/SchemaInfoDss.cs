using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.CloudServiceModels
{
    public partial class SchemaInfoDss
    {
        public int SchemaMajorVersion { get; set; }
        public int SchemaMinorVersion { get; set; }
        public string SchemaExtendedInfo { get; set; } = null!;
    }
}
