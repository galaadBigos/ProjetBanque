using ProjetBanque.dto;

namespace ProjetBanque.Abstractions.Services
{
	public interface IBanqueService
	{
		List<ClientDTO> RecupererCLientsDTO();
		List<CompteDTO> RecupererComptesDTO();
		List<CompteDTO> RecupererComptesDTOParClient(string numeroClient);
	}
}
