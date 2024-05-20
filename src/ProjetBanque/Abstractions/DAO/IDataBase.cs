using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Abstractions.DAO
{
    public interface IDataBase
    {
        List<IClient>? RecupererClients(string nomBanque);
        List<ICompte>? RecupererComptes(string nomBanque);
    }
}