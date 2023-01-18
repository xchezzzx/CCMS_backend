using ASPNETCore.DataAccess.Models.DBModels;
using SharedLib.DataTransferModels;

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
                StateId = (int)competitionDT.StateId
                
            };
        }

		public static Exercise ExerciseParser(ExerciseDT exerciseDT)
		{

			return new Exercise()
			{
				Name = exerciseDT.Name,
                Content = exerciseDT.Content,
                CategoryId = exerciseDT.CategoryId,
                LangId = exerciseDT.LangId,
                PlatformId = exerciseDT.PlatformId,
                Timeframe = exerciseDT.Timeframe,
                Points = exerciseDT.Points,
                Fine = exerciseDT.Fine,
                IfHasBonus = exerciseDT.IfHasBonus,
                BonusContent = exerciseDT.BonusContent,
                BonusTimeframe = exerciseDT.BonusTimeframe,
                BonusPoints = exerciseDT.BonusPoints
			};
		}

		public static Team TeamParser(TeamDT teamDT)
		{

			return new Team()
			{
				Name = teamDT.Name,
                Icon = teamDT.Icon,
                SumPoints = teamDT.SumPoints
			};
		}

        public static ExerciseCategory ExerciseCategoryParser(ExerciseCategoryDT exerciseCategoryDT)
        {
            return new ExerciseCategory()
            {
                Name = exerciseCategoryDT.Name,
                CreateDate = exerciseCategoryDT.CreateDate,
                UpdateDate = exerciseCategoryDT.UpdateDate,
                CreateUserId = exerciseCategoryDT.CreateUserId,
                UpdateUserId = exerciseCategoryDT.UpdateUserId,
                StatusId = (int)exerciseCategoryDT.StatusId,
            };
        }

        public static ExerciseLang ExerciseLangParser(ExerciseLangDT exerciseLangDT)
        {
            return new ExerciseLang()
            {
                Name = exerciseLangDT.Name,
                CreateDate = exerciseLangDT.CreateDate,
                CreateUserId = exerciseLangDT.CreateUserId,
                UpdateDate  = exerciseLangDT.UpdateDate,
                UpdateUserId = exerciseLangDT.UpdateUserId,
                StatusId = (int)(exerciseLangDT.StatusId)
			};
        }

        public static ExercisePlatform ExercisePlatformParser(ExercisePlatformDT exercisePlatformDT)
        {
            return new ExercisePlatform()
            {
                Name = exercisePlatformDT.Name,
                CreateDate = exercisePlatformDT.CreateDate,
                CreateUserId = exercisePlatformDT.CreateUserId,
                UpdateDate = exercisePlatformDT.UpdateDate,
                UpdateUserId = exercisePlatformDT.UpdateUserId,
                StatusId = (int)exercisePlatformDT.StatusId
			};
        }
	}
}
