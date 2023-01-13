using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class Team
    {
        public Team()
        {
            CompetitionsToTeams = new HashSet<CompetitionsToTeam>();
            CompetitionsToTeamsToTasks = new HashSet<CompetitionsToTeamsToExercise>();
            CompetitionsToTeamsToUsers = new HashSet<CompetitionsToTeamsToUser>();
        }


        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[]? Icon { get; set; }
        public int? SumPoints { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual User CreateUser { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual User UpdateUser { get; set; } = null!;
        public virtual ICollection<CompetitionsToTeam> CompetitionsToTeams { get; set; }
        public virtual ICollection<CompetitionsToTeamsToExercise> CompetitionsToTeamsToTasks { get; set; }
        public virtual ICollection<CompetitionsToTeamsToUser> CompetitionsToTeamsToUsers { get; set; }
    }
}
