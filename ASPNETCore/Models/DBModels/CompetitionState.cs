using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class CompetitionState
    {
        public CompetitionState()
        {
            Competitions = new HashSet<Competition>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Competition> Competitions { get; set; }
    }
}
