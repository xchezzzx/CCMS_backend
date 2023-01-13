using ASPNETCore.Interfaces.Common;
using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class CompetitionsToTeam : IFillable
    {
        public CompetitionsToTeam(int competitionId, int teamId) 
        {
            CompetitionId = competitionId;
            TeamId = teamId;
            TakenTasks = 0;
            TeamPoints = 0;
        }

        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int TeamId { get; set; }
        public int? TakenTasks { get; set; }
        public int? TeamPoints { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual Competition Competition { get; set; } = null!;
        public virtual User CreateUser { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
        public virtual User UpdateUser { get; set; } = null!;
    }
}
