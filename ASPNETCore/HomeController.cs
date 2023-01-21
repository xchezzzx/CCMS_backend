using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore
{
	public class HomeController : Controller
	{
		[Authorize]
		[Route("/a")]
		public string Index()
		{
			return "!!";
		}
	}
}
