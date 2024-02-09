using ProjetBanque.Abstractions.DAO;
using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Data
{
	public class BanqueDAO : IBanqueDAO
	{
		private readonly DbFake _dbFake;

		public BanqueDAO(DbFake dbFake)
		{
			_dbFake = dbFake;
		}

		public List<IClient> RecupererClients()
			=> _dbFake.RecupererFakeClients();

		public List<ICompte> RecupererComptes()
			=> _dbFake.RecupererFakeComptes();

		public List<ICompte> RecupererComptesParClient(string numeroClient)
			=> _dbFake.RecupererFakeComptes().FindAll(c => c.Client.NumeroClient == numeroClient);
	}
}
