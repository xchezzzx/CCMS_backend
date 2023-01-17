namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class Competition : ICRUDEntity
    {
        public Competition()
        {
            ExercisesToCompetitions = new HashSet<ExercisesToCompetition>();
            ExercisesToTeams = new HashSet<ExercisesToTeam>();
            OperatorsToCompetitions = new HashSet<OperatorsToCompetition>();
            TeamsToCompetitions = new HashSet<TeamsToCompetition>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int NumberConcTasks { get; set; }
        public string Hashtag { get; set; }
        public int StateId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual CompetitionState State { get; set; }
        public virtual Status Status { get; set; }
        public virtual User UpdateUser { get; set; }
        public virtual ICollection<ExercisesToCompetition> ExercisesToCompetitions { get; set; }
        public virtual ICollection<ExercisesToTeam> ExercisesToTeams { get; set; }
        public virtual ICollection<OperatorsToCompetition> OperatorsToCompetitions { get; set; }
        public virtual ICollection<TeamsToCompetition> TeamsToCompetitions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
