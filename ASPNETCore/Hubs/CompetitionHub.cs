using ASPNETCore.BuisnessLogic.Managers.CompetitionsManager;
using ASPNETCore.BuisnessLogic.Providers.EntityProvider;
using ASPNETCore.DataAccess.Models.DBModels;
using ASPNETCore.Helpers;
using Microsoft.AspNetCore.SignalR;
using SharedLib.DataTransferModels;

namespace ASPNETCore.Hubs
{
    public class CompetitionHub: Hub
    {

        private readonly ICompetitionManager _competitionManager;

        public CompetitionHub(ICompetitionManager competitionManager)
        {
            _competitionManager = competitionManager;
;
		}

        public async Task GetAllCompetitions()
        {

            var competitionsDT = await _competitionManager.GetAllCompetitionsAsync();

            await Clients.All.SendAsync("Get", competitionsDT);
        }


        public async Task GetCompetitionById()
        {
            //var competitions = _competitionRepository.GetAllCompetitions;

            //List<CompetitionDT> competitionsDT = new();

            //foreach (var c in competitions)
            //{
            //    competitionsDT.Add(ToDTModelsParsers.DTCompetitionParser(c));
            //}

            //await Clients.All.SendAsync("Get", competitionsDT);
        }

        public async Task AddNewCompetition(CompetitionDT competitionDT)
        {
            string res = "failed";

            if (competitionDT != null)
            {
                await _competitionManager.CreateNewCompetitionAsync(competitionDT, 1);
				res = "success";
            }

            await Clients.Caller.SendAsync("Add", res);
        }

        
    }

}