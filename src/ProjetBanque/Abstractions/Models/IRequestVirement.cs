namespace ProjetBanque.Abstractions.Models
{
	public interface IRequestVirement
	{
		public string NomBanqueDebiteur { get; set; }
		public string NomBanqueCrediteur { get; set; }
		public string NumeroCompteDebiteur { get; set; }
		public string NumeroCompteCrediteur { get; set; }
		public double Somme { get; set; }
	}
}
