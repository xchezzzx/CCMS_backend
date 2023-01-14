using ASPNETCore.Models.DBModels;
using ASPNETCore.Models.DTModels;

namespace ASPNETCore.Helpers
{
    public class ToDTModelsParsers
    {
        public static CompetitionDT DTCompetitionParser(Competition competition)
        {

            return new CompetitionDT()
            {
                Id = competition.Id,
                Name = competition.Name,
                Duration = competition.Duration,
                EndDateTime = competition.EndDateTime,
                StartDateTime = competition.StartDateTime,
                NumberConcTasks = competition.NumberConcTasks,
                Hashtag = competition.Hashtag,
                    
            };
        }
    }
}

