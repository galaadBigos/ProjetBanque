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

		public IActionResult RecupererComptes(string nomBanque)
		{
			try
			{
				var result = _banqueService.RecupererComptesDTO(nomBanque);
				if (result is null)
					return NotFound();
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		public IActionResult RecupererComptesParClient(string nomBanque, string numeroClient)
		{
			try
			{
				var result = _banqueService.RecupererComptesDTOParClient(nomBanque, numeroClient);
				if (result is null)
					return NotFound();
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
