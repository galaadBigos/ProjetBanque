using ProjetBanque.Abstractions.DAO;
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

		public List<ClientDTO> RecupererCLientsDTO()
		{
			var clients = _banqueDAO.RecupererClients();

			return clients.Select(c => (ClientDTO)c.ConvertirEnDTO()).ToList();
		}

		public List<CompteDTO> RecupererComptesDTO()
		{
			var comptes = _banqueDAO.RecupererComptes();

			return comptes.Select(c => (CompteDTO)c.ConvertirEnDTO()).ToList();
		}

		public List<CompteDTO>? RecupererComptesDTOParClient(string numeroClient)
		{
			var comptes = _banqueDAO.RecupererComptesParClient(numeroClient);

			if(comptes != null)
				return comptes.Select(c => (CompteDTO)c.ConvertirEnDTO()).ToList() ?? null;
			
			return null;

		}
	}
}
