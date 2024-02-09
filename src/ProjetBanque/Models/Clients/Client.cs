using ProjetBanque.Abstractions.Models;
using ProjetBanque.dto;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Models.Clients
{
	public class Client(string numeroClient, string adresse, string nom) : IEntite, IClient
	{
		public string NumeroClient { get; set; } = numeroClient;
		public string Adresse { get; set; } = adresse;
		public string Nom { get; set; } = nom;
		public IBanque Banque { get; set; }
		public List<Compte> Comptes { get; set; } = [];

		public override ClientDTO ConvertirEnDTO()
		{
			return new ClientDTO
			{
				NumeroClient = NumeroClient,
				Adresse = Adresse,
				Nom = Nom,
				Banque = RecupererBanqueDTO()
			};
		}

		private BanqueDTO RecupererBanqueDTO()
		{
			return new BanqueDTO();
		}
	}
}
