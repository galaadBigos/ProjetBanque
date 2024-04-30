using Microsoft.AspNetCore.Mvc;
using ProjetBanque.Models.Virements;

namespace ProjetBanque.Controllers
{
	public class VirementController : ControllerBase
	{
		private string _baseUrl = "http://localhost:5092";

		public VirementController()
		{
		}

		[HttpPost("/FaireVirementInterne")]
		public async Task<IActionResult> VirementInterneAsync([FromBody] RequestVirement request)
		{
			//string authorizationHeader = HttpContext.Request.Headers["Authorization"];

			string url = _baseUrl + $"/VirementInterne?nomBanqueDebiteur={request.NomBanqueDebiteur}&nomBanqueCrediteur={request.NomBanqueCrediteur}&numeroCompteDebiteur={request.NumeroCompteDebiteur}&numeroCompteCrediteur={request.NumeroCompteCrediteur}&somme={request.Somme}";
			return await AppelServiceExterne(url);
		}

		[HttpPost("/FaireVirementExterne")]
		public async Task<IActionResult> VirementExterneAsync(string nomBanqueDebiteur, string nomBanqueCrediteur, string numeroCompteDebiteur, string numeroCompteCrediteur, double somme)
		{
			string url = _baseUrl + $"VirementExterne?nomBanqueDebiteur={nomBanqueDebiteur}&nomBanqueCrediteur={nomBanqueCrediteur}&numeroCompteDebiteur={numeroCompteDebiteur}&numeroCompteCrediteur={numeroCompteCrediteur}&somme={somme}";
			return await AppelServiceExterne(url);
		}

		private async Task<IActionResult> AppelServiceExterne(string url)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(url);

					if (response.IsSuccessStatusCode)
					{
						string json = await response.Content.ReadAsStringAsync();
						return Ok(json);
					}
					else
					{
						string json = await response.Content.ReadAsStringAsync();
						return BadRequest(json);
					}
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
