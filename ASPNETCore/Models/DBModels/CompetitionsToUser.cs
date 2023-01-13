using ASPNETCore.Interfaces.Common;
using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class CompetitionsToUser : IFillable
    {
        public CompetitionsToUser(int competitionId, int administratorId) 
        { 
            CompetitionId = competitionId;
            UserId = administratorId;
        }


        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual Competition Competition { get; set; } = null!;
        public virtual User CreateUser { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual User UpdateUser { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
