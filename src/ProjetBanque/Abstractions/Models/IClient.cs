using ProjetBanque.Abstractions.DTO;
using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Abstractions
{
	public interface IClient
	{
		string Adresse { get; set; }
		List<ICompte> Comptes { get; set; }
		string Nom { get; set; }
		string NumeroClient { get; set; }

		IDTO ConvertirEnDTO();
	}
}