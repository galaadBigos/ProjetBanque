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

		public List<IClient> RecupererClients(string nomBanque)
			=> _dataBase.RecupererClients(nomBanque) ?? new List<IClient>();

		public List<ICompte> RecupererComptes(string nomBanque)
			=> _dataBase.RecupererComptes(nomBanque) ?? new List<ICompte>();

		public List<ICompte>? RecupererComptesParClient(string nomBanque, string numeroClient)
			=> _dataBase.RecupererClients(nomBanque)?.Find(c => c.NumeroClient == numeroClient)?.Comptes;
	}
}
