using ASPNETCore.Interfaces.Common;
using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class Competition : ICRUDEntity
    {
        public Competition()
        {
            TeamsToCompetitions = new HashSet<TeamsToCompetition>();
            Users = new HashSet<User>();
            UsersToCompetitions = new HashSet<UsersToCompetition>();
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
        public virtual ICollection<TeamsToCompetition> TeamsToCompetitions { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UsersToCompetition> UsersToCompetitions { get; set; }
    }
}
