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

        private readonly ICompetition _competitionRepository;

        public CompetitionHub(ICompetition iCompetiton)
        {
            _competitionRepository = iCompetiton;
        }

        public async Task GetAllCompetitions()
        {
            List<Competition> competitions = _competitionRepository.GetAllCompetitions;

            List<CompetitionDT> competitionsDT = new();

            foreach (var c in competitions)
            {
                competitionsDT.Add(ToDTModelsParsers.DTCompetitionParser(c));
            }

            await Clients.All.SendAsync("Get", competitionsDT);
        }


        public async Task GetCompetitionById()
        {
            Competition competitions = _competitionRepository.GetAllCompetitions;

            List<CompetitionDT> competitionsDT = new();

            foreach (var c in competitions)
            {
                competitionsDT.Add(ToDTModelsParsers.DTCompetitionParser(c));
            }

            await Clients.All.SendAsync("Get", competitionsDT);
        }

        public async Task AddNewCompetition(CompetitionDT competitionDT)
        {
            string res = "failed";

            Competition competition = ToDBModelsParsers.CompetitionParser(competitionDT);
            FillEntityHelper.CreateEntity(ref competition, 1);

            if (competition != null)
            {
                _competitionRepository.AddCompetiton(competition);
                res = "success";
            }

            await Clients.Caller.SendAsync("Add", res);
        }

        
    }

}