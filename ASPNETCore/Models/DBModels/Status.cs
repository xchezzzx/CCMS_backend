using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
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
            ExercisesToTeams = new HashSet<ExercisesToTeam>();
            Teams = new HashSet<Team>();
            TeamsToCompetitions = new HashSet<TeamsToCompetition>();
            Users = new HashSet<User>();
            UsersToCompetitions = new HashSet<UsersToCompetition>();
            UsersToTeams = new HashSet<UsersToTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<ExerciseCategory> ExerciseCategories { get; set; }
        public virtual ICollection<ExerciseLang> ExerciseLangs { get; set; }
        public virtual ICollection<ExercisePlatform> ExercisePlatforms { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<ExercisesToTeam> ExercisesToTeams { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<TeamsToCompetition> TeamsToCompetitions { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UsersToCompetition> UsersToCompetitions { get; set; }
        public virtual ICollection<UsersToTeam> UsersToTeams { get; set; }
    }
}
