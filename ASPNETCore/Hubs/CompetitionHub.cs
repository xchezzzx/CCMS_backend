using ASPNETCore.Helpers;
using ASPNETCore.Models.DTModels;
using ASPNETCore.Models.DBModels;
using ASPNETCore.Repositories;
using Microsoft.AspNetCore.SignalR;
using ASPNETCore.Interfaces;

namespace ASPNETCore.Hubs
{
    public class CompetitionHub: Hub
    {

        private readonly IRepository<Competition> _competitionRepository;

        public CompetitionHub(IRepository<Competition> competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }

        public async Task GetAllCompetitions()
        {
			
			var	competitions = await _competitionRepository.GetAllCompetitions();

            List<CompetitionDT> competitionsDT = new();

            foreach (var c in competitions)
            {
                competitionsDT.Add(ToDTModelsParsers.DTCompetitionParser(c));
            }

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

            Competition competition = ToDBModelsParsers.CompetitionParser(competitionDT);
            FillEntityHelper.CreateEntity(ref competition, 1);

            if (competition != null)
            {
                //_competitionRepository.AddCompetiton(competition);
                res = "success";
            }

            await Clients.Caller.SendAsync("Add", res);
        }

        
    }

}