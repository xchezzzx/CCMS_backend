using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.CloudServiceModels
{
    public partial class CompetitionsToUsersDssTracking
    {
        public int Id { get; set; }
        public int? UpdateScopeLocalId { get; set; }
        public int? ScopeUpdatePeerKey { get; set; }
        public long? ScopeUpdatePeerTimestamp { get; set; }
        public int LocalUpdatePeerKey { get; set; }
        public byte[] LocalUpdatePeerTimestamp { get; set; } = null!;
        public int? CreateScopeLocalId { get; set; }
        public int? ScopeCreatePeerKey { get; set; }
        public long? ScopeCreatePeerTimestamp { get; set; }
        public int LocalCreatePeerKey { get; set; }
        public long LocalCreatePeerTimestamp { get; set; }
        public int SyncRowIsTombstone { get; set; }
        public DateTime? LastChangeDatetime { get; set; }
    }
}
