using ASPNETCore.Interfaces.Common;
using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class Exercise : IFillable
    {
        public Exercise()
        {
            CompetitionsToTeamsToTasks = new HashSet<CompetitionsToTeamsToExercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int CategoryId { get; set; }
        public int LangId { get; set; }
        public int PlatformId { get; set; }
        public TimeSpan Timeframe { get; set; }
        public int Points { get; set; }
        public int Fine { get; set; }
        public bool IfHasBonus { get; set; }
        public string? BonusContent { get; set; }
        public int? BonusTimeframe { get; set; }
        public int? BonusPoints { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual ExerciseCategory Category { get; set; } = null!;
        public virtual User CreateUser { get; set; } = null!;
        public virtual ExerciseLang Lang { get; set; } = null!;
        public virtual ExercisePlatform Platform { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual User UpdateUser { get; set; } = null!;
        public virtual ICollection<CompetitionsToTeamsToExercise> CompetitionsToTeamsToTasks { get; set; }
    }
}
