namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class ExerciseState
    {
        public ExerciseState()
        {
            ExercisesToTeams = new HashSet<ExercisesToTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExercisesToTeam> ExercisesToTeams { get; set; }
    }
}
