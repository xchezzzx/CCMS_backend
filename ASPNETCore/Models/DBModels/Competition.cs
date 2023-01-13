using ASPNETCore.Interfaces.Common;

namespace ASPNETCore.Models.DBModels
{
    public partial class Competition : IFillable
    {
        public Competition()
        {
            CompetitionsToTeams = new HashSet<CompetitionsToTeam>();
            CompetitionsToTeamsToTasks = new HashSet<CompetitionsToTeamsToExercise>();
            CompetitionsToTeamsToUsers = new HashSet<CompetitionsToTeamsToUser>();
            CompetitionsToUsers = new HashSet<CompetitionsToUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int NumberConcTasks { get; set; }
        public string Hashtag { get; set; } = null!;
        public int StateId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual User CreateUser { get; set; } = null!;
        public virtual CompetitionState State { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual User UpdateUser { get; set; } = null!;
        public virtual ICollection<CompetitionsToTeam> CompetitionsToTeams { get; set; }
        public virtual ICollection<CompetitionsToTeamsToExercise> CompetitionsToTeamsToTasks { get; set; }
        public virtual ICollection<CompetitionsToTeamsToUser> CompetitionsToTeamsToUsers { get; set; }
        public virtual ICollection<CompetitionsToUser> CompetitionsToUsers { get; set; }
    }
}
