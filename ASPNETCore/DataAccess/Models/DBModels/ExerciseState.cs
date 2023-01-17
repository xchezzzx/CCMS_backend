namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class ExerciseState
    {
        public ExerciseState()
        {
            ExercisesToTeams = new HashSet<ExercisesToTeamToCompetition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExercisesToTeamToCompetition> ExercisesToTeams { get; set; }
    }
}
