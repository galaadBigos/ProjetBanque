using ProjetBanque.Models.Banques;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Models.Clients
{
	public class Client(string numeroClient, string adresse, string nom)
	{
		public string NumeroClient { get; set; } = numeroClient;
		public string Adresse { get; set; } = adresse;
		public string Nom { get; set; } = nom;
		public Banque Banque { get; set; }
		public List<Compte> Comptes { get; set; } = [];
	}
}
