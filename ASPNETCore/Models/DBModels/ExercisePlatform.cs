using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class ExercisePlatform
    {
        public ExercisePlatform()
        {
            Exercises = new HashSet<Exercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual Status Status { get; set; }
        public virtual User UpdateUser { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
