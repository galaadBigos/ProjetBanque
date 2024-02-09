using ProjetBanque.dto;

namespace ProjetBanque.Abstractions.Models
{
	public interface IBanque
	{
		List<IClient> Clients { get; set; }
		List<ICompte> Comptes { get; set; }

		DTO ConvertirEnDTO();
		double? Depot(string numeroCompte, string nomClient, double montant);
		double? Retrait(string numeroCompte, string nomClient, double montant);
	}
}