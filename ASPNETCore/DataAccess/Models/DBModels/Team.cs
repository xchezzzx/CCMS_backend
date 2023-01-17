namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class Team : ICRUDEntity
    {
        public Team()
        {
            ExercisesToTeams = new HashSet<ExercisesToTeamToCompetition>();
            TeamsToCompetitions = new HashSet<TeamsToCompetition>();
            UsersToTeams = new HashSet<UsersToTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Icon { get; set; }
        public int? SumPoints { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual Status Status { get; set; }
        public virtual User UpdateUser { get; set; }
        public virtual ICollection<ExercisesToTeamToCompetition> ExercisesToTeams { get; set; }
        public virtual ICollection<TeamsToCompetition> TeamsToCompetitions { get; set; }
        public virtual ICollection<UsersToTeam> UsersToTeams { get; set; }
    }
}
