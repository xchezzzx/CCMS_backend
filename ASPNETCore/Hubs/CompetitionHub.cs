using ASPNETCore.BuisnessLogic.Managers.CompetitionsManager;
using Microsoft.AspNetCore.SignalR;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Services.ExceptionBuilderService;

namespace ASPNETCore.Hubs
{
    public class CompetitionHub: Hub
    {

        private readonly ICompetitionManager _competitionManager;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public CompetitionHub(ICompetitionManager competitionManager, IExceptionBuilderService exceptionBuilderService)
        {
            _competitionManager = competitionManager;
            _exceptionBuilderService = exceptionBuilderService;
		}

        public async Task GetAllCompetitions()
        {

            List<CompetitionDT> competitionsDT;
            try
			{
				competitionsDT = await _competitionManager.GetAllCompetitionsAsync();
			}
            catch
            {
                throw;
            }

            await Clients.All.SendAsync("Get", competitionsDT);
        }


        public async Task GetCompetitionById()
        {

        }

        public async Task AddNewCompetition(CompetitionDT competitionDT)
        {
            string res = "success";


			try
			{
				if (competitionDT == null)
                {
                    throw _exceptionBuilderService.ParseException(ExceptionCodes.HubMethodNullArgumentException, nameof(competitionDT));
                }

				await _competitionManager.CreateNewCompetitionAsync(competitionDT, 1);
			}
            catch
            {
				res = "failed";
			}

            await Clients.Caller.SendAsync("Add", res);
        }

        
    }

}