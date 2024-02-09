using Microsoft.AspNetCore.Mvc;
using ProjetBanque.Models.Clients;

namespace ProjetBanque.Controllers
{
	public class ClientsController : Controller
	{
		public IActionResult Index()
		{
			return Ok(new Client("f", "g", "gg"));
		}

		public IActionResult GetAllClients()
		{
			return Ok(new Client("f", "g", "gg"));
		}
	}
}
