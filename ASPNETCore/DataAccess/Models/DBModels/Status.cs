namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class Status
    {
        public Status()
        {
            Competitions = new HashSet<Competition>();
            ExerciseCategories = new HashSet<ExerciseCategory>();
            ExerciseLangs = new HashSet<ExerciseLang>();
            ExercisePlatforms = new HashSet<ExercisePlatform>();
            Exercises = new HashSet<Exercise>();
            ExercisesToCompetitions = new HashSet<ExercisesToCompetition>();
            ExercisesToTeams = new HashSet<ExercisesToTeamToCompetition>();
            OperatorsToCompetitions = new HashSet<OperatorsToCompetition>();
            Teams = new HashSet<Team>();
            TeamsToCompetitions = new HashSet<TeamsToCompetition>();
            Users = new HashSet<User>();
            UsersToTeams = new HashSet<UsersToTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<ExerciseCategory> ExerciseCategories { get; set; }
        public virtual ICollection<ExerciseLang> ExerciseLangs { get; set; }
        public virtual ICollection<ExercisePlatform> ExercisePlatforms { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<ExercisesToCompetition> ExercisesToCompetitions { get; set; }
        public virtual ICollection<ExercisesToTeamToCompetition> ExercisesToTeams { get; set; }
        public virtual ICollection<OperatorsToCompetition> OperatorsToCompetitions { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<TeamsToCompetition> TeamsToCompetitions { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UsersToTeam> UsersToTeams { get; set; }
    }
}
