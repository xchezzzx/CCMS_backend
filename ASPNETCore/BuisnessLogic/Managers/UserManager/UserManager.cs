using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using Microsoft.CodeAnalysis.Editing;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;

namespace ASPNETCore.BuisnessLogic.Managers.UserManager
{
    public class UserManager : IUserManager
	{
		private readonly IEntityProvider<User> _userEntityProvider;
		private readonly IEntityProvider<OperatorsToCompetition> _operatorsToCompetitionEntityProvider;
		private readonly IEntityProvider<UsersToTeam> _usersToTeamEntityProvider;
		private readonly IEntityProvider<Competition> _competitionEntityProvider;
		private readonly IEntityProvider<TeamsToCompetition> _teamsToCompetitionEntityProvider;

		public UserManager(IEntityProvider<TeamsToCompetition> teamsToCompetitionEntityProvider, IEntityProvider<Competition> competitionEntityProvider, IEntityProvider<User> userEntityProvider, IEntityProvider<OperatorsToCompetition> operatorsEntityProvider, IEntityProvider<UsersToTeam> usersToTeamEntityProvider)
		{
			_userEntityProvider = userEntityProvider;
			_operatorsToCompetitionEntityProvider = operatorsEntityProvider;
			_usersToTeamEntityProvider = usersToTeamEntityProvider;
			_competitionEntityProvider = competitionEntityProvider;
			_teamsToCompetitionEntityProvider = teamsToCompetitionEntityProvider;

		}
		public async Task<UserDT> GetCurrentUserAsync(UserDT userDT)
		{
			try
			{
				var user = (await _userEntityProvider.GetActiveEntitiesWithIncludeAsync(c => c.Password == userDT.Password)).FirstOrDefault();
				userDT = ToDTModelsParsers.DTUserParser(user);
			}
			catch 
			{
				try
				{
                    var user = ToDBModelsParsers.UserParser(userDT);
                    user = await _userEntityProvider.AddNewEntityAsync(user, 1);
                    userDT = ToDTModelsParsers.DTUserParser(user);
                }
				catch 
				{

					throw;
				}

				throw;
			}
			return userDT;
		}

		public async Task<UserDT> AddNewUserAsync(UserDT userDT, int userCreateId)
		{
			try
			{
				var user = ToDBModelsParsers.UserParser(userDT);
				user = await _userEntityProvider.AddNewEntityAsync(user, userCreateId);
				userDT = ToDTModelsParsers.DTUserParser(user);
			}
			catch
			{
				throw;
			}
			return userDT;
		}

        public async Task<List<UserDT>> GetAllUsersAsync()
        {
			List<UserDT> usersDT = new();
			try
			{
				var users = await _userEntityProvider.GetAllEntitiesWithIncludeAsync(c => c.CreateUser, c => c.UpdateUser, c => c.Status);
				foreach (var user in users)
				{
					usersDT.Add(ToDTModelsParsers.DTUserParser(user));
				}
			}
			catch 
			{

				throw;
			}
			return usersDT;
        }

        public async Task<List<UserDT>> GetActiveUsersAsync()
        {
            List<UserDT> usersDT = new();
            try
            {
                var users = await _userEntityProvider.GetActiveEntitiesWithIncludeAsync(c => c.CreateUser, c => c.UpdateUser, c => c.Status);
                foreach (var user in users)
                {
                    usersDT.Add(ToDTModelsParsers.DTUserParser(user));
                }
            }
            catch
            {

                throw;
            }
            return usersDT;
        }

        public async Task UpdateUserAsync(UserDT userDT, int userUpdateId)
        {
            try
            {
				var user = ToDBModelsParsers.UserParser(userDT);
                await _userEntityProvider.UpdateEntityAsync(user, userUpdateId);
            }
            catch
            {

                throw;
            }
        }

        public async Task DeleteUserByIdAsync(int userId, int userUpdateId)
        {

            try
            {
				var user = await _userEntityProvider.GetActiveEntityByIdWithIncludeAsync(userId);
                await _userEntityProvider.DeleteEntityAsync(user, userUpdateId);
            }
            catch
            {

                throw;
            }
        }

        public async Task AssignRoleToUserAsync(int userId, Roles role, int userUpdateId)
        {
            try
            {
                var user = await _userEntityProvider.GetActiveEntityByIdWithIncludeAsync(userId);
                user.RoleId = (int)role;
                await _userEntityProvider.UpdateEntityAsync(user, userUpdateId);
            }
            catch
            {
                throw;
            }
        }

		public async Task<CompetitionDT> GetOperatorCurrentOrNearestCompetitionAsync(int operatorId)
		{
			CompetitionDT competitionDT = new();
			try
			{
				var competitionIds = (await _operatorsToCompetitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.UserId == operatorId)).Select(x => x.CompetitionId).ToList();

				try
				{
					var currentCompetition = (await _competitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.StateId == (int)CompetitionStates.InProgress && competitionIds.Contains(x.Id)))[0];
					competitionDT = ToDTModelsParsers.DTCompetitionParser(currentCompetition);
				}
				catch 
				{
					var nearestCompetitions = await _competitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.StateId == (int)CompetitionStates.Planned && competitionIds.Contains(x.Id));
					var nearestCompetition = nearestCompetitions.OrderBy(x => x.StartDateTime).ToList()[0];
					competitionDT = ToDTModelsParsers.DTCompetitionParser(nearestCompetition);
				}
				
			}
			catch 
			{

				throw;
			}

			return competitionDT;
		}

		public async Task<CompetitionDT> GetParticipantCurrentOrNearestCompetitionAsync(int participantId)
		{
			CompetitionDT competitionDT = new();
			try
			{
				var teamId = (await _usersToTeamEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.UserId == participantId)).FirstOrDefault().Id;
				var competitionIds = (await _teamsToCompetitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.TeamId == teamId)).Select(x => x.CompetitionId).ToList();
				try
				{
					var currentCompetition = (await _competitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.StateId == (int)CompetitionStates.InProgress && competitionIds.Contains(x.Id)))[0];
					competitionDT = ToDTModelsParsers.DTCompetitionParser(currentCompetition);
				}
				catch
				{
					var nearestCompetitions = await _competitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.StateId == (int)CompetitionStates.Planned && competitionIds.Contains(x.Id));
					var nearestCompetition = nearestCompetitions.OrderBy(x => x.StartDateTime).ToList()[0];
					competitionDT = ToDTModelsParsers.DTCompetitionParser(nearestCompetition);
				}

			}
			catch
			{

				throw;
			}

			return competitionDT;
		}

		public async Task<List<CompetitionDT>> GetFiveCurrentOrNearestCompetitionsAsync()
		{
			List<CompetitionDT> competitionsDT = new();
			try
			{
				try
				{
					var currentCompetitions = await _competitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.StateId == (int)CompetitionStates.InProgress);
					if (currentCompetitions.Count >= 5)
					{
						foreach (var comeptition in currentCompetitions)
						{
							competitionsDT.Add(ToDTModelsParsers.DTCompetitionParser(comeptition));
						}
					}
					else
					{
						var nearestCompetitions = (await _competitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.StateId == (int)CompetitionStates.Planned)).OrderBy(x => x.StartDateTime).ToList();
						foreach (var comeptition in nearestCompetitions)
						{
							competitionsDT.Add(ToDTModelsParsers.DTCompetitionParser(comeptition));
							if (competitionsDT.Count >= 5) break;
						}
					}
					
				}
				catch
				{
					var nearestCompetitions = (await _competitionEntityProvider.GetActiveEntitiesWithIncludeAsync(x => x.StateId == (int)CompetitionStates.Planned)).OrderBy(x => x.StartDateTime).ToList();
					foreach (var comeptition in nearestCompetitions)
					{
						competitionsDT.Add(ToDTModelsParsers.DTCompetitionParser(comeptition));
						if (competitionsDT.Count >= 5) break;
					}
				}

			}
			catch
			{

				throw;
			}

			return competitionsDT;
		}

		public async Task<TeamDT> GetParticipantTeamAsync(int participantId)
		{
			TeamDT teamDT = new();
			try
			{
				var participant = await _usersToTeamEntityProvider.GetActiveEntityByIdWithIncludeAsync(participantId, x => x.Team);
				teamDT = ToDTModelsParsers.DTTeamParser(participant.Team);
			}
			catch 
			{
				throw;
			}
			return teamDT;
		}
	}
}
