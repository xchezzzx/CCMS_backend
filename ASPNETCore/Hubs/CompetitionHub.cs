using ASPNETCore.Helpers;
using ASPNETCore.Models.DBModels;
using ASPNETCore.Models.DTModels;
using ASPNETCore.Providers.EntityProvider;
using ASPNETCore.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace ASPNETCore.Hubs
{
    public class CompetitionHub: Hub
    {

        private readonly IEntityProvider<Competition> _competitionRepository;

        public CompetitionHub(IEntityProvider<Competition> competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }

        public async Task GetAllCompetitions()
        {

            var competitions = await _competitionRepository.GetAllEntitiesWithIncludeAsync(x=>x.CreateUser, p=>p.State, p=>p.Status);

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