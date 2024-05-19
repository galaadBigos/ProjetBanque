using ProjetBanque.Abstractions.DTO;

namespace ProjetBanque.dto
{
	public abstract class CompteDTO : IDTO
	{
		public double Solde { get; set; }
		public string NumeroCompte { get; set; }
	}
}
