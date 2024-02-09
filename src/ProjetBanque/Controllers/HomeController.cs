using Microsoft.AspNetCore.Mvc;
using ProjetBanque.Models;
using ProjetBanque.Models.Clients;
using System.Diagnostics;

namespace ProjetBanque.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet("GetAllClient")]
		public IActionResult GetAllClient()
		{
			return Ok(new Client("f", "g", "gg"));
		}
	}
}
