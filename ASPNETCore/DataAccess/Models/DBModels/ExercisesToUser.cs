namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class ExercisesToUser 
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int UserId { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual User User { get; set; }
    }
}
