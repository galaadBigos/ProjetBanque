using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Abstractions.DAO
{
	public interface IBanqueDAO
	{
		List<ICompte> RecupererComptes();
		List<IClient> RecupererClients();
		List<ICompte>? RecupererComptesParClient(string numeroClient);
	}
}
