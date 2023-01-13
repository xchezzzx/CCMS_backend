using ASPNETCore.Constants;
using ASPNETCore.Interfaces.Common;
using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class CompetitionsToTeamsToExercise : IFillable
    {
        public CompetitionsToTeamsToExercise(int competitionId, int teamId, Exercise exercise) 
        {
            CompetitionId = competitionId;
            TeamId = teamId;
            TaskId = exercise.Id;
            TakeTime = DateTime.Now;
            Timeframe = exercise.Timeframe;
            TaskStateId = (int)ExerciseStates.notTaken;
        }

        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int TeamId { get; set; }
        public int TaskId { get; set; }
        public DateTime TakeTime { get; set; }
        public DateTime? SubmitTime { get; set; } = null;
        public TimeSpan Timeframe { get; set; }
        public TimeSpan? SubmitDuration { get; set; } = null;
        public int TaskStateId { get; set; }
        public string? SolutionLink { get; set; } = null;
        public string? Comment { get; set; } = null;
        public string? FileLink { get; set; } = null;
        public int? ApprovedPoints { get; set; } = null;
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual Competition Competition { get; set; } = null!;
        public virtual User CreateUser { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual Exercise Task { get; set; } = null!;
        public virtual ExerciseState TaskState { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
        public virtual User UpdateUser { get; set; } = null!;
    }
}
