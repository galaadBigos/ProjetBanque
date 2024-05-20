using ProjetBanque.Abstractions.Models;
using ProjetBanque.dto;

namespace ProjetBanque.Models.Clients
{
    public class Client(string numeroClient, string adresse, string nom) : IEntite, IClient
    {
        public string NumeroClient { get; set; } = numeroClient;
        public string Adresse { get; set; } = adresse;
        public string Nom { get; set; } = nom;
        public List<ICompte> Comptes { get; set; } = [];

        public override ClientDTO ConvertirEnDTO()
        {
            return new ClientDTO
            {
                NumeroClient = NumeroClient,
                Adresse = Adresse,
                Nom = Nom,
            };
        }
    }
}