using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Abstractions.DAO
{
    public interface IBanqueDAO
    {
        List<IClient> RecupererClients(string nomBanque);
        List<ICompte> RecupererComptes(string nomBanque);
        List<ICompte>? RecupererComptesParClient(string nomBanque, string numeroClient);
    }
}