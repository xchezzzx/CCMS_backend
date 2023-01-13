using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class TeamState
    {
        public TeamState()
        {
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Team> Teams { get; set; }
    }
}
