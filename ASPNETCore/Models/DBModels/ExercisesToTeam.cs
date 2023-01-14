using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class ExercisesToTeam
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime TakeTime { get; set; }
        public DateTime? SubmitTime { get; set; }
        public TimeSpan Timeframe { get; set; }
        public TimeSpan? SubmitDuration { get; set; }
        public int ExerciseStateId { get; set; }
        public string SolutionLink { get; set; }
        public string Comment { get; set; }
        public string FileLink { get; set; }
        public int? ApprovedPoints { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual Exercise Exercise { get; set; }
        public virtual ExerciseState ExerciseState { get; set; }
        public virtual Status Status { get; set; }
        public virtual Team Team { get; set; }
        public virtual User UpdateUser { get; set; }
    }
}
