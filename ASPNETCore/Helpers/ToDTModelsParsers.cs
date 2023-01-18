using ASPNETCore.DataAccess.Models.DBModels;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;

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
                Status = ((EntityStatuses)competition.StatusId).ToString(),
				StatusId = (EntityStatuses)competition.StatusId
			};
        }

        public static UserDT DTUserParser(User user)
        {
            return new UserDT()
            {
                Id = user.Id,
                FirstName = user.FirstName,  
                LastName= user.LastName,
				Email = user.Email,
                Password = user.Password,
                PointsSummary = user.PointsSummary,
                Role = ((Roles)user.RoleId).ToString(),
                RoleId = (Roles)user.RoleId,

				CreateDate = user.CreateDate,
				CreateUserId = user.CreateUserId,
				UpdateDate = user.UpdateDate,
				UpdateUserId = user.UpdateUserId,
				Status = ((EntityStatuses)user.StatusId).ToString(),
                StatusId = (EntityStatuses)user.StatusId
			};
        }

		public static TeamDT DTTeamParser(Team team)
		{
			return new TeamDT()
			{
				Id = team.Id,
				Name = team.Name,
				Icon = team.Icon,
                SumPoints = team.SumPoints,

				CreateDate = team.CreateDate,
				CreateUserId = team.CreateUserId,
				UpdateDate = team.UpdateDate,
				UpdateUserId = team.UpdateUserId,
				Status = ((EntityStatuses)team.StatusId).ToString(),
				StatusId = (EntityStatuses)team.StatusId
			};
		}

		public static ExerciseDT DTExerciseParser(Exercise exercise)
		{
			return new ExerciseDT()
			{
				Id = exercise.Id,
				Name = exercise.Name,
				CategoryId = exercise.CategoryId,
				LangId = exercise.LangId,
				PlatformId = exercise.PlatformId,
				Timeframe = exercise.Timeframe,
				Points = exercise.Points,
				Fine = exercise.Fine,
				IfHasBonus = exercise.IfHasBonus,
				BonusContent = exercise.BonusContent,
				BonusTimeframe = exercise.BonusTimeframe,
				BonusPoints = exercise.BonusPoints,

				CreateDate = exercise.CreateDate,
				CreateUserId = exercise.CreateUserId,
				UpdateDate = exercise.UpdateDate,
				UpdateUserId = exercise.UpdateUserId,
				Status = ((EntityStatuses)exercise.StatusId).ToString(),
				StatusId = (EntityStatuses)exercise.StatusId
			};
		}

		public static ExerciseCategoryDT DTExerciseCategoryParser(ExerciseCategory category)
		{
			return new ExerciseCategoryDT()
			{
				Id = category.Id,
				Name = category.Name,

				CreateDate = category.CreateDate,
				CreateUserId = category.CreateUserId,
				UpdateDate = category.UpdateDate,
				UpdateUserId = category.UpdateUserId,
				Status = ((EntityStatuses)category.StatusId).ToString(),
				StatusId = (EntityStatuses)category.StatusId
			};
		}

		public static ExerciseLangDT DTExerciseLanguageParser(ExerciseLang lang)
		{
			return new ExerciseLangDT()
			{
				Id = lang.Id,
				Name = lang.Name,

				CreateDate = lang.CreateDate,
				CreateUserId = lang.CreateUserId,
				UpdateDate = lang.UpdateDate,
				UpdateUserId = lang.UpdateUserId,
				Status = ((EntityStatuses)lang.StatusId).ToString(),
				StatusId = (EntityStatuses)lang.StatusId
			};
		}

		public static ExercisePlatformDT DTExercisePlatformParser(ExercisePlatform platform)
		{
			return new ExercisePlatformDT()
			{
				Id = platform.Id,
				Name = platform.Name,

				CreateDate = platform.CreateDate,
				CreateUserId = platform.CreateUserId,
				UpdateDate = platform.UpdateDate,
				UpdateUserId = platform.UpdateUserId,
				Status = ((EntityStatuses)platform.StatusId).ToString(),
				StatusId = (EntityStatuses)platform.StatusId
			};
		}

	}
}

