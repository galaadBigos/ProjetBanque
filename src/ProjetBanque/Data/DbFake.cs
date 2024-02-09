using ProjetBanque.Abstractions.Models;
using ProjetBanque.Models.Banques;
using ProjetBanque.Models.Clients;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.Data
{
	public class DbFake
	{
		private IBanque _banque;
		private List<IClient> _clients;
		private List<ICompte> _comptes;

		public DbFake()
		{
			_banque = new Banque();

			_clients = new()
			{
				new Client("C0121", "13 rue de Metz", "Ludovic Wagner"),
				new Client("C0126", "13 rue de Metz", "Donia Zmander"),
				new Client("C0151", "13 rue de Metz", "Brice Orliange"),
				new Client("C0151", "13 rue de Metz", "Galaad Bigs")
			};

			foreach (IClient client in _clients)
			{
				CompteAvecDecouvert compteAvecDecouvert = new("125", 500.0d)
				{
					Client = client,
					Banque = _banque,
				};
				CompteSansDecouvert compteSansDecouvert = new("125")
				{
					Client = client,
					Banque = _banque,
				};

				client.Comptes.AddRange([compteAvecDecouvert, compteSansDecouvert]);

				_banque.Comptes.AddRange([compteAvecDecouvert, compteSansDecouvert]);

				client.Banque = _banque;
			}
		}

		public List<IClient> RecupererFakeClients()
			=> _clients;

		public List<ICompte> RecupererFakeComptes()
			=> _banque.Comptes;
	}
}
