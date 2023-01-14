using ASPNETCore.DataAccess.Models.DBModels;
using SharedLib.DataTransferModels;
using SharedLib.Enums;

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
                State = ((CompetitionStates)competition.StateId).ToString(),
                StateId = (CompetitionStates)competition.StateId,

                CreateDate = competition.CreateDate,
                CreateUserId = competition.CreateUserId,
                UpdateDate = competition.UpdateDate,
                UpdateUserId = competition.UpdateUserId,
                Status = ((EntityStatuses)competition.StatusId).ToString()
			};
        }
    }
}

