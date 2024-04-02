using Microsoft.AspNetCore.Mvc;
using ProjetBanque.Abstractions.DAO;
using ProjetBanque.Abstractions.Models;

namespace VirementService.Controllers
{
	[ApiController]
	public class VirementController : ControllerBase
	{
		private readonly IDataBase _dataBase;

		public VirementController(IDataBase dataBase)
		{
			_dataBase = dataBase;
		}

		[HttpGet("/VirementInterne")]
		public IActionResult VirementInterne(string nomBanqueDebiteur, string nomBanqueCrediteur, string numeroCompteDebiteur, string numeroCompteCrediteur, double somme)
		{
			if (nomBanqueDebiteur != nomBanqueCrediteur)
				return BadRequest("Impossible de faire un virement dans une banque externe");

			try
			{
				return FaireVirement(nomBanqueDebiteur, nomBanqueCrediteur, numeroCompteDebiteur, numeroCompteCrediteur, somme);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpGet("/VirementExterne")]
		public IActionResult VirementExterne(string nomBanqueDebiteur, string nomBanqueCrediteur, string numeroCompteDebiteur, string numeroCompteCrediteur, double somme)
		{
			if (nomBanqueDebiteur == nomBanqueCrediteur)
				return BadRequest("Impossible de faire un virement dans la même banque");

			try
			{
				return FaireVirement(nomBanqueDebiteur, nomBanqueCrediteur, numeroCompteDebiteur, numeroCompteCrediteur, somme);

			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		private IActionResult FaireVirement(string nomBanqueDebiteur, string nomBanqueCrediteur, string numeroCompteDebiteur, string numeroCompteCrediteur, double somme)
		{
			ICompte? compteDebiteur = RecupererCompte(nomBanqueDebiteur, numeroCompteDebiteur);
			ICompte? compteCrediteur = RecupererCompte(nomBanqueCrediteur, numeroCompteCrediteur);

			if (compteDebiteur is null || compteCrediteur is null)
				return BadRequest("Compte introuvable");

			if (compteDebiteur.Debiter(somme) is null)
				return BadRequest("Le compte débiteur n'a pas assez de blé");
			compteCrediteur.Crediter(somme);

			return Ok("Le virement a bien été effectuée");
		}

		private ICompte? RecupererCompte(string nomBanque, string numeroCompte)
			=> _dataBase.RecupererComptes(nomBanque)?.FirstOrDefault(c => c.NumeroCompte == numeroCompte);
	}
}
