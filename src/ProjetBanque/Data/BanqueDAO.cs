using ProjetBanque.Abstractions;
using ProjetBanque.Abstractions.DAO;
using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Data
{
	public class BanqueDAO : IBanqueDAO
	{
		private readonly IDataBase _dataBase;

		public BanqueDAO(IDataBase dataBase)
		{
			_dataBase = dataBase;
		}

		public List<IClient> RecupererClients()
			=> _dataBase.RecupererClients();

		public List<ICompte> RecupererComptes()
			=> _dataBase.RecupererComptes();

		public List<ICompte>? RecupererComptesParClient(string numeroClient)
			=> _dataBase.RecupererClients().Find(c => c.NumeroClient == numeroClient)?.Comptes;
	}
}
