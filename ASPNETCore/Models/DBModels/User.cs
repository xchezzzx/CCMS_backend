using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class User
    {
        public User()
        {
            CompetitionCreateUsers = new HashSet<Competition>();
            CompetitionUpdateUsers = new HashSet<Competition>();
            CompetitionsToTeamCreateUsers = new HashSet<CompetitionsToTeam>();
            CompetitionsToTeamUpdateUsers = new HashSet<CompetitionsToTeam>();
            CompetitionsToTeamsToTaskCreateUsers = new HashSet<CompetitionsToTeamsToExercise>();
            CompetitionsToTeamsToTaskUpdateUsers = new HashSet<CompetitionsToTeamsToExercise>();
            CompetitionsToTeamsToUserCreateUsers = new HashSet<CompetitionsToTeamsToUser>();
            CompetitionsToTeamsToUserUpdateUsers = new HashSet<CompetitionsToTeamsToUser>();
            CompetitionsToTeamsToUserUsers = new HashSet<CompetitionsToTeamsToUser>();
            CompetitionsToUserCreateUsers = new HashSet<CompetitionsToUser>();
            CompetitionsToUserUpdateUsers = new HashSet<CompetitionsToUser>();
            CompetitionsToUserUsers = new HashSet<CompetitionsToUser>();
            InverseCreateUser = new HashSet<User>();
            InverseUpdateUser = new HashSet<User>();
            TaskCreateUsers = new HashSet<Exercise>();
            TaskUpdateUsers = new HashSet<Exercise>();
            TeamCreateUsers = new HashSet<Team>();
            TeamUpdateUsers = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public int? PointsSummary { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual User CreateUser { get; set; } = null!;
        public virtual UserRole Role { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual User UpdateUser { get; set; } = null!;
        public virtual ICollection<Competition> CompetitionCreateUsers { get; set; }
        public virtual ICollection<Competition> CompetitionUpdateUsers { get; set; }
        public virtual ICollection<CompetitionsToTeam> CompetitionsToTeamCreateUsers { get; set; }
        public virtual ICollection<CompetitionsToTeam> CompetitionsToTeamUpdateUsers { get; set; }
        public virtual ICollection<CompetitionsToTeamsToExercise> CompetitionsToTeamsToTaskCreateUsers { get; set; }
        public virtual ICollection<CompetitionsToTeamsToExercise> CompetitionsToTeamsToTaskUpdateUsers { get; set; }
        public virtual ICollection<CompetitionsToTeamsToUser> CompetitionsToTeamsToUserCreateUsers { get; set; }
        public virtual ICollection<CompetitionsToTeamsToUser> CompetitionsToTeamsToUserUpdateUsers { get; set; }
        public virtual ICollection<CompetitionsToTeamsToUser> CompetitionsToTeamsToUserUsers { get; set; }
        public virtual ICollection<CompetitionsToUser> CompetitionsToUserCreateUsers { get; set; }
        public virtual ICollection<CompetitionsToUser> CompetitionsToUserUpdateUsers { get; set; }
        public virtual ICollection<CompetitionsToUser> CompetitionsToUserUsers { get; set; }
        public virtual ICollection<User> InverseCreateUser { get; set; }
        public virtual ICollection<User> InverseUpdateUser { get; set; }
        public virtual ICollection<Exercise> TaskCreateUsers { get; set; }
        public virtual ICollection<Exercise> TaskUpdateUsers { get; set; }
        public virtual ICollection<Team> TeamCreateUsers { get; set; }
        public virtual ICollection<Team> TeamUpdateUsers { get; set; }
    }
}
