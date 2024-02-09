using ProjetBanque.Abstractions;
using ProjetBanque.Abstractions.DTO;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.dto;

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

		private ICompte? RecupererCompte(IClient client, string numeroCompte)
			=> client.Comptes.Find(c => c.NumeroCompte == numeroCompte);

		public override IDTO ConvertirEnDTO()
		{
			List<ClientDTO> clientsDTO = Clients.Select(c => (ClientDTO)c.ConvertirEnDTO()).ToList();

			return new BanqueDTO { Clients = clientsDTO, Comptes = GetCompteDTO() };
		}

		private List<ClientDTO> GetClientDTO()
		{
			return [];
		}

		private List<CompteDTO> GetCompteDTO()
		{
			return [];
		}
	}
}
