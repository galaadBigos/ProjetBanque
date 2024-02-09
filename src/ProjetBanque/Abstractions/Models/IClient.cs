using ProjetBanque.dto;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Abstractions.Models
{
	public interface IClient
	{
		string Adresse { get; set; }
		IBanque Banque { get; set; }
		List<Compte> Comptes { get; set; }
		string Nom { get; set; }
		string NumeroClient { get; set; }

		DTO ConvertirEnDTO();
	}
}