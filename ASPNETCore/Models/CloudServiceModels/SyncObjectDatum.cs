using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.CloudServiceModels
{
    public partial class SyncObjectDatum
    {
        public Guid ObjectId { get; set; }
        public int DataType { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? DroppedTime { get; set; }
        public byte[] LastModified { get; set; } = null!;
        public byte[] ObjectData { get; set; } = null!;
    }
}
