using ProjetBanque.Models.Clients;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Models.Banques
{
	public class Banque
	{
		public List<Client> Clients { get; set; } = [];
		public List<Compte> Comptes { get; set; } = [];

		public double? Retrait(string numeroCompte, string nomClient, double montant)
			=> Clients.Find(c => c.Nom == nomClient)?
				.Comptes.Find(c => c.NumeroCompte == numeroCompte)?
				.Debiter(montant);

		public double? Depot(string numeroCompte, string nomClient, double montant)
			=> Clients.Find(c => c.Nom == nomClient)?
				.Comptes.Find(c => c.NumeroCompte == numeroCompte)?
				.Crediter(montant);

	}
}
