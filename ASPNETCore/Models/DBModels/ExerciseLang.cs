using System;
using System.Collections.Generic;

namespace ASPNETCore.Models.DBModels
{
    public partial class ExerciseLang
    {
        public ExerciseLang()
        {
            Tasks = new HashSet<Exercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Exercise> Tasks { get; set; }
    }
}
