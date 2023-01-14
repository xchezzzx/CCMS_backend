using ASPNETCore.Interfaces.Common;
using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class User : ICRUDEntity
	{
        public User()
        {
            CompetitionCreateUsers = new HashSet<Competition>();
            CompetitionUpdateUsers = new HashSet<Competition>();
            ExerciseCategoryCreateUsers = new HashSet<ExerciseCategory>();
            ExerciseCategoryUpdateUsers = new HashSet<ExerciseCategory>();
            ExerciseCreateUsers = new HashSet<Exercise>();
            ExerciseLangCreateUsers = new HashSet<ExerciseLang>();
            ExerciseLangUpdateUsers = new HashSet<ExerciseLang>();
            ExercisePlatformCreateUsers = new HashSet<ExercisePlatform>();
            ExercisePlatformUpdateUsers = new HashSet<ExercisePlatform>();
            ExerciseUpdateUsers = new HashSet<Exercise>();
            ExercisesToTeamCreateUsers = new HashSet<ExercisesToTeam>();
            ExercisesToTeamUpdateUsers = new HashSet<ExercisesToTeam>();
            ExercisesToUsers = new HashSet<ExercisesToUser>();
            InverseCreateUser = new HashSet<User>();
            InverseUpdateUser = new HashSet<User>();
            TeamCreateUsers = new HashSet<Team>();
            TeamUpdateUsers = new HashSet<Team>();
            TeamsToCompetitionCreateUsers = new HashSet<TeamsToCompetition>();
            TeamsToCompetitionUpdateUsers = new HashSet<TeamsToCompetition>();
            UsersToCompetitionCreateUsers = new HashSet<UsersToCompetition>();
            UsersToCompetitionUpdateUsers = new HashSet<UsersToCompetition>();
            UsersToCompetitionUsers = new HashSet<UsersToCompetition>();
            UsersToTeamCreateUsers = new HashSet<UsersToTeam>();
            UsersToTeamUpdateUsers = new HashSet<UsersToTeam>();
            UsersToTeamUsers = new HashSet<UsersToTeam>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int? PointsSummary { get; set; }
        public int? CurrentCompetitionId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual Competition CurrentCompetition { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual Status Status { get; set; }
        public virtual User UpdateUser { get; set; }
        public virtual ICollection<Competition> CompetitionCreateUsers { get; set; }
        public virtual ICollection<Competition> CompetitionUpdateUsers { get; set; }
        public virtual ICollection<ExerciseCategory> ExerciseCategoryCreateUsers { get; set; }
        public virtual ICollection<ExerciseCategory> ExerciseCategoryUpdateUsers { get; set; }
        public virtual ICollection<Exercise> ExerciseCreateUsers { get; set; }
        public virtual ICollection<ExerciseLang> ExerciseLangCreateUsers { get; set; }
        public virtual ICollection<ExerciseLang> ExerciseLangUpdateUsers { get; set; }
        public virtual ICollection<ExercisePlatform> ExercisePlatformCreateUsers { get; set; }
        public virtual ICollection<ExercisePlatform> ExercisePlatformUpdateUsers { get; set; }
        public virtual ICollection<Exercise> ExerciseUpdateUsers { get; set; }
        public virtual ICollection<ExercisesToTeam> ExercisesToTeamCreateUsers { get; set; }
        public virtual ICollection<ExercisesToTeam> ExercisesToTeamUpdateUsers { get; set; }
        public virtual ICollection<ExercisesToUser> ExercisesToUsers { get; set; }
        public virtual ICollection<User> InverseCreateUser { get; set; }
        public virtual ICollection<User> InverseUpdateUser { get; set; }
        public virtual ICollection<Team> TeamCreateUsers { get; set; }
        public virtual ICollection<Team> TeamUpdateUsers { get; set; }
        public virtual ICollection<TeamsToCompetition> TeamsToCompetitionCreateUsers { get; set; }
        public virtual ICollection<TeamsToCompetition> TeamsToCompetitionUpdateUsers { get; set; }
        public virtual ICollection<UsersToCompetition> UsersToCompetitionCreateUsers { get; set; }
        public virtual ICollection<UsersToCompetition> UsersToCompetitionUpdateUsers { get; set; }
        public virtual ICollection<UsersToCompetition> UsersToCompetitionUsers { get; set; }
        public virtual ICollection<UsersToTeam> UsersToTeamCreateUsers { get; set; }
        public virtual ICollection<UsersToTeam> UsersToTeamUpdateUsers { get; set; }
        public virtual ICollection<UsersToTeam> UsersToTeamUsers { get; set; }
    }
}
