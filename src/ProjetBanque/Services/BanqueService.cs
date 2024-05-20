using ProjetBanque.Abstractions.DAO;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.Abstractions.Services;
using ProjetBanque.dto;

namespace ProjetBanque.Services
{
    public class BanqueService : IBanqueService
    {
        private readonly IBanqueDAO _banqueDAO;

        public BanqueService(IBanqueDAO _banqueDAO)
        {
            this._banqueDAO = _banqueDAO;
        }

        public List<ClientDTO> RecupererClientsDTO(string nomBanque)
        {
            var clients = _banqueDAO.RecupererClients(nomBanque) ?? new List<IClient>();

            return clients.Select(c => (ClientDTO)c.ConvertirEnDTO()).ToList();
        }

        public List<CompteDTO> RecupererComptesDTO(string nomBanque)
        {
            var comptes = _banqueDAO.RecupererComptes(nomBanque) ?? new List<ICompte>();

            return comptes.Select(c => (CompteDTO)c.ConvertirEnDTO()).ToList();
        }

        public List<CompteDTO>? RecupererComptesDTOParClient(string nomBanque, string numeroClient)
        {
            var comptes = _banqueDAO.RecupererComptesParClient(nomBanque, numeroClient);

            if (comptes != null)
                return comptes.Select(c => (CompteDTO)c.ConvertirEnDTO()).ToList() ?? null;

            return null;
        }
    }
}