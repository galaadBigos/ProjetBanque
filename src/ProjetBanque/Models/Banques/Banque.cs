using ProjetBanque.dto;
using ProjetBanque.Models.Clients;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Models.Banques
{
	public class Banque : IEntite
	{
		public List<Client> Clients { get; set; } = [];
		public List<Compte> Comptes { get; set; } = [];

		public double? Retrait(string numeroCompte, string nomClient, double montant)
		{
			Client? client = RecupererClient(nomClient);

			if (client is not null)
				return RecupererCompte(client, numeroCompte)?.Debiter(montant);

			return null;
		}

		public double? Depot(string numeroCompte, string nomClient, double montant)
		{
			Client? client = RecupererClient(nomClient);

			if (client is not null)
				return RecupererCompte(client, numeroCompte)?.Crediter(montant);

			return null;
		}

		private Client? RecupererClient(string nomClient)
			=> Clients.Find(c => c.Nom == nomClient);

		private Compte? RecupererCompte(Client client, string numeroCompte)
			=> client.Comptes.Find(c => c.NumeroCompte == numeroCompte);

        public override DTO ConvertirEnDTO()
        {
            return new BanqueDTO {Clients = GetClientDTO(), Comptes = GetCompteDTO()};
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
