using ASPNETCore.Constants;
using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Models.DTModels
{
    public class CompetitionDT
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int NumberConcTasks { get; set; }
        public string Hashtag { get; set; } = null!;
        public CompetitionStates State { get; set; }

        // Service fields
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public EntityStatuses Status { get; set; }
    }
}
