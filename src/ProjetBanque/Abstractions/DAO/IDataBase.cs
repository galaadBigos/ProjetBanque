using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Abstractions.DAO
{
    public interface IDataBase
    {
        List<IClient> RecupererClients();
        List<ICompte> RecupererComptes();
    }
}