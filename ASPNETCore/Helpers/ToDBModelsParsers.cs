using ASPNETCore.Models.DTModels;
using ASPNETCore.Models.DBModels;

namespace ASPNETCore.Helpers
{
    public class ToDBModelsParsers
    {
        public static Competition CompetitionParser(CompetitionDT competitionDT) 
        {

            return new Competition()
            {
                Name = competitionDT.Name,
                Duration = competitionDT.Duration,
                StartDateTime = competitionDT.StartDateTime,
                EndDateTime = competitionDT.EndDateTime,
                NumberConcTasks = competitionDT.NumberConcTasks,
                Hashtag = competitionDT.Hashtag,
                StateId = 1,
                StatusId = 1,
                CreateUserId= 1,
                UpdateUserId= 1,
                CreateDate = DateTime.Now,
                UpdateDate= DateTime.Now,
            };
        }
    }
}
