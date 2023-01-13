using ASPNETCore.Models.DBModels;
using ASPNETCore.Models.DTModels;

namespace ASPNETCore.Helpers
{
    public class ToDTModelsParsers
    {
        public static CompetitionDT DTCompetitionParser<T>(T competition)
        {

            if (competition is Competition)
            {
                Competition c = (Competition)(object)competition;

                return new CompetitionDT()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Duration = c.Duration,
                    EndDateTime = c.EndDateTime,
                    StartDateTime = c.StartDateTime,
                    NumberConcTasks = c.NumberConcTasks,
                    Hashtag =   c.Hashtag,
                    State = c.State.Name,
                    Status = c.Status.Name
                };
            }
            else return new CompetitionDT();  
        }
    }
}

