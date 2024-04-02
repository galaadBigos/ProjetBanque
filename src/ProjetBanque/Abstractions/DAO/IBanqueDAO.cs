using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Abstractions.DAO
{
	public interface IBanqueDAO
	{
		List<ICompte> RecupererComptes(string nomBanque);
		List<IClient> RecupererClients(string nomBanque);
		List<ICompte>? RecupererComptesParClient(string nomBanque, string numeroClient);
	}
}
