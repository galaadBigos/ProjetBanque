using ProjetBanque.dto;

namespace ProjetBanque.Abstractions.Services
{
	public interface IBanqueService
	{
		List<ClientDTO> RecupererCLientsDTO(string nomBanque);
		List<CompteDTO>? RecupererComptesDTO(string nomBanque);
		List<CompteDTO>? RecupererComptesDTOParClient(string nomBanque, string numeroClient);
	}
}
