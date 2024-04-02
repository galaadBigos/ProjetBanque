using Microsoft.AspNetCore.Mvc;

namespace VirementService.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return Ok();
		}
	}
}
