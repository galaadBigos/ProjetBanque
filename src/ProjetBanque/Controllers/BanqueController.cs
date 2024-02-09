using Microsoft.AspNetCore.Mvc;
using ProjetBanque.Abstractions.Services;

namespace ProjetBanque.Controllers
{
	public class BanqueController : Controller
	{
		private readonly IBanqueService _banqueService;

		public BanqueController(IBanqueService banqueService)
		{
			_banqueService = banqueService;
		}

		public IActionResult RecupererComptes()
			=> Ok(_banqueService.RecupererComptesDTO());

		public IActionResult RecupererComptesParClient(string numeroClient)
			=> Ok(_banqueService.RecupererComptesDTOParClient(numeroClient));
	}
}
