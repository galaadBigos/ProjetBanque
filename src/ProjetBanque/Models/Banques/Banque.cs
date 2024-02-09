using ProjetBanque.Abstractions.Models;
using ProjetBanque.dto;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Models.Banques
{
	public class Banque : IEntite, IBanque
	{
		public List<IClient> Clients { get; set; } = [];
		public List<ICompte> Comptes { get; set; } = [];

		public double? Retrait(string numeroCompte, string nomClient, double montant)
		{
			IClient? client = RecupererClient(nomClient);

			if (client is not null)
				return RecupererCompte(client, numeroCompte)?.Debiter(montant);

			return null;
		}

		public double? Depot(string numeroCompte, string nomClient, double montant)
		{
			IClient? client = RecupererClient(nomClient);

			if (client is not null)
				return RecupererCompte(client, numeroCompte)?.Crediter(montant);

			return null;
		}

		private IClient? RecupererClient(string nomClient)
			=> Clients.Find(c => c.Nom == nomClient);

		private Compte? RecupererCompte(IClient client, string numeroCompte)
			=> client.Comptes.Find(c => c.NumeroCompte == numeroCompte);

		public override DTO ConvertirEnDTO()
		{
			List<ClientDTO> clientsDTO = Clients.Select(c => (ClientDTO)c.ConvertirEnDTO()).ToList();

			return new BanqueDTO { Clients = clientsDTO, Comptes = GetCompteDTO() };
		}

		private List<ClientDTO> GetClientDTO()
		{
			return new List<ClientDTO>();
		}

		private List<CompteDTO> GetCompteDTO()
		{
			return new List<CompteDTO>();
		}
	}
}
