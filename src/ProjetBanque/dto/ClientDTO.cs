using ProjetBanque.Models.Banques;

namespace ProjetBanque.dto
{
	public class ClientDTO : DTO
	{

		public string NumeroClient { get; set; }
		public string Adresse { get; set; }
		public string Nom { get; set; }
		public BanqueDTO Banque { get; set; }
		public List<CompteDTO> Comptes { get; set; }

		public ClientDTO()
		{
		}

		





	}
}
