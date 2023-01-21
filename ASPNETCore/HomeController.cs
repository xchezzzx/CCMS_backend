using ASPNETCore.BuisnessLogic.Managers.CompetitionsManager;
using ASPNETCore.DataAccess.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLib.DataTransferModels;

namespace ASPNETCore
{
	public class HomeController : Controller
	{

		ICompetitionManager context;

		public HomeController(ICompetitionManager context)
		{
			this.context = context;
		}

		[Authorize]
		[Route("index")]
		public async Task<List<CompetitionDT>> Index()
		{
			return await context.GetAllCompetitionsAsync();
		}
	}
}
