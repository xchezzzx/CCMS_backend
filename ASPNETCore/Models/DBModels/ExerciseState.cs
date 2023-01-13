using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class ExerciseState
    {
        public ExerciseState()
        {
            CompetitionsToTeamsToTasks = new HashSet<CompetitionsToTeamsToExercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CompetitionsToTeamsToExercise> CompetitionsToTeamsToTasks { get; set; }
    }
}
