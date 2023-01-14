using System;
using System.Collections.Generic;

namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class ExercisesToUser : ICRUDEntity
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int UserId { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual User User { get; set; }
        public int StatusId { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
