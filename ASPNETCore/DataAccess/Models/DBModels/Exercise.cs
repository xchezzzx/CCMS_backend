namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class Exercise : ICRUDEntity
	{
        public Exercise()
        {
            ExercisesToCompetitions = new HashSet<ExercisesToCompetition>();
            ExercisesToTeams = new HashSet<ExercisesToTeamToCompetition>();
            ExercisesToUsersToCompetitions = new HashSet<ExercisesToUsersToCompetition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int LangId { get; set; }
        public int PlatformId { get; set; }
        public TimeSpan Timeframe { get; set; }
        public int Points { get; set; }
        public int Fine { get; set; }
        public bool IfHasBonus { get; set; }
        public string BonusContent { get; set; }
        public TimeSpan? BonusTimeframe { get; set; }
        public int? BonusPoints { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual ExerciseCategory Category { get; set; }
        public virtual User CreateUser { get; set; }
        public virtual ExerciseLang Lang { get; set; }
        public virtual ExercisePlatform Platform { get; set; }
        public virtual Status Status { get; set; }
        public virtual User UpdateUser { get; set; }
        public virtual ICollection<ExercisesToCompetition> ExercisesToCompetitions { get; set; }
        public virtual ICollection<ExercisesToTeamToCompetition> ExercisesToTeams { get; set; }
        public virtual ICollection<ExercisesToUsersToCompetition> ExercisesToUsersToCompetitions { get; set; }
    }
}
