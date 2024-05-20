using ProjetBanque.Abstractions.DAO;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.Models.Banques;
using ProjetBanque.Models.Clients;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Data
{
    public class DbFake : IDataBase
    {
        private List<IBanque> _banques = new();
        private List<IClient> _clients;

        public DbFake()
        {
            for (int i = 0; i < 3; i++)
            {
                var _banque = new Banque() { Nom = "LGBD" + i };
                _banques.Add(_banque);

                _clients = new()
                {
                    new Client("C0121" + i, "13 rue de Metz", "Ludovic Wagner"),
                    new Client("C0126" + i, "13 rue de Metz", "Donia Zmander"),
                    new Client("C0151" + i, "13 rue de Metz", "Brice Orliange"),
                };
                _banque.Clients = _clients;

                foreach (IClient client in _clients)
                {
                    CompteAvecDecouvert compteAvecDecouvert = new("125" + i, 500.0d) { Solde = i * 1_000.0d };
                    CompteSansDecouvert compteSansDecouvert = new("126" + i) { Solde = i * 1_000.0d };

                    client.Comptes.AddRange([compteAvecDecouvert, compteSansDecouvert]);
                    _banque.Comptes.AddRange([compteAvecDecouvert, compteSansDecouvert]);
                }
            }
        }

        public List<IClient>? RecupererClients(string nomBanque)
            => _banques.FirstOrDefault(b => b.Nom == nomBanque)?.Clients;

        public List<ICompte>? RecupererComptes(string nomBanque)
            => _banques.FirstOrDefault(b => b.Nom == nomBanque)?.Comptes;
    }
}