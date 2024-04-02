using ProjetBanque.Abstractions.DTO;

namespace ProjetBanque.Abstractions.Models
{
	public interface IBanque
	{
		public string Nom { get; set; }
		List<IClient> Clients { get; set; }
		List<ICompte> Comptes { get; set; }

		IDTO ConvertirEnDTO();
		double? Depot(string numeroCompte, string nomClient, double montant);
		double? Retrait(string numeroCompte, string nomClient, double montant);
	}
}