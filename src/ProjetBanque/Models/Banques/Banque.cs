using ProjetBanque.Abstractions.Models;
using ProjetBanque.dto;

namespace ProjetBanque.Models.Banques
{
    public class Banque : IEntite, IBanque
    {
        public string Nom { get; set; } = string.Empty;
        public List<IClient> Clients { get; set; } = [];
        public List<ICompte> Comptes { get; set; } = [];

        public double? Depot(string numeroCompte, string nomClient, double montant)
        {
            IClient? client = RecupererClient(nomClient);

            if (client is not null)
                return RecupererCompte(client, numeroCompte)?.Crediter(montant);

            return null;
        }

        public double? Retrait(string numeroCompte, string nomClient, double montant)
        {
            IClient? client = RecupererClient(nomClient);

            if (client is not null)
                return RecupererCompte(client, numeroCompte)?.Debiter(montant);

            return null;
        }

        private IClient? RecupererClient(string nomClient)
            => Clients.Find(c => c.Nom == nomClient);

        private ICompte? RecupererCompte(IClient client, string numeroCompte)
            => client.Comptes.Find(c => c.NumeroCompte == numeroCompte);

        public override BanqueDTO ConvertirEnDTO()
        {
            return new BanqueDTO
            {
                Nom = Nom,
                Clients = GetClientsDto(),
                Comptes = GetComptesDto()
            };
        }

        private List<ClientDTO> GetClientsDto()
        {
            return Clients.Select(c => (ClientDTO)c.ConvertirEnDTO()).ToList();
        }

        private List<CompteDTO> GetComptesDto()
        {
            return Comptes.Select(c => (CompteDTO)c.ConvertirEnDTO()).ToList();
        }
    }
}