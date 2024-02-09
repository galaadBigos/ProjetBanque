using ProjetBanque.dto;
using ProjetBanque.Models.Clients;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Abstractions.Models
{
	public interface IBanque
	{
		List<Client> Clients { get; set; }
		List<Compte> Comptes { get; set; }

		DTO ConvertirEnDTO();
		double? Depot(string numeroCompte, string nomClient, double montant);
		double? Retrait(string numeroCompte, string nomClient, double montant);
	}
}