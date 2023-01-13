using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class Status
    {
        public Status()
        {
            Competitions = new HashSet<Competition>();
            CompetitionsToTeams = new HashSet<CompetitionsToTeam>();
            CompetitionsToTeamsToTasks = new HashSet<CompetitionsToTeamsToExercise>();
            CompetitionsToTeamsToUsers = new HashSet<CompetitionsToTeamsToUser>();
            CompetitionsToUsers = new HashSet<CompetitionsToUser>();
            Tasks = new HashSet<Exercise>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<CompetitionsToTeam> CompetitionsToTeams { get; set; }
        public virtual ICollection<CompetitionsToTeamsToExercise> CompetitionsToTeamsToTasks { get; set; }
        public virtual ICollection<CompetitionsToTeamsToUser> CompetitionsToTeamsToUsers { get; set; }
        public virtual ICollection<CompetitionsToUser> CompetitionsToUsers { get; set; }
        public virtual ICollection<Exercise> Tasks { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
