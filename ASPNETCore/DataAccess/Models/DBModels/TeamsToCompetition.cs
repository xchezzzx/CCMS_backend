namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class TeamsToCompetition : ICRUDEntity
	{
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int TeamId { get; set; }
        public int? TakenTasks { get; set; }
        public int? TeamPoints { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public int StatusId { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual User CreateUser { get; set; }
        public virtual Status Status { get; set; }
        public virtual Team Team { get; set; }
        public virtual User UpdateUser { get; set; }
    }
}
