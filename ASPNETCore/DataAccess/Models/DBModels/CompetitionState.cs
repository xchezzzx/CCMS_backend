namespace ASPNETCore.DataAccess.Models.DBModels
{
    public partial class CompetitionState
	{
        public CompetitionState()
        {
            Competitions = new HashSet<Competition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
    }
}
