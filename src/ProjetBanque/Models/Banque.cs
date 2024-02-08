using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Models
{
	public class Banque
	{
		public List<Client> Clients { get; set; } = new List<Client>();
		public List<Compte> Comptes { get; set; } = new List<Compte>();

		public double? Retrait(string numeroCompte, string nomClient, double montant)
			=> Clients.FirstOrDefault(c => c.Nom == nomClient)?
				.Comptes.FirstOrDefault(c => c.NumeroCompte == numeroCompte)?
				.Debiter(montant);

		public double? Depot(string numeroCompte, string nomClient, double montant)
			=> Clients.FirstOrDefault(c => c.Nom == nomClient)?
				.Comptes.FirstOrDefault(c => c.NumeroCompte == numeroCompte)?
				.Crediter(montant);

	}
}
