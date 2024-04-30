using Microsoft.AspNetCore.Mvc;
using ProjetBanque.Models.Virements;

namespace ProjetBanque.Controllers
{
	public class VirementController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private string _baseUrl = "";

		public VirementController(IConfiguration configuration)
		{
			_configuration = configuration;
			_baseUrl = _configuration.GetValue<string>("ApiVirementUrl");
		}

		[HttpPost("/FaireVirementInterne")]
		public async Task<IActionResult> VirementInterneAsync([FromBody] RequestVirement request)
		{
			//string url = _baseUrl + $"VirementInterne?nomBanqueDebiteur={nomBanqueDebiteur}&nomBanqueCrediteur={nomBanqueCrediteur}&numeroCompteDebiteur={numeroCompteDebiteur}&numeroCompteCrediteur={numeroCompteCrediteur}&somme={somme}";
			return await AppelServiceExterne("f");
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
