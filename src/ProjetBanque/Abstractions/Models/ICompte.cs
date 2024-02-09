namespace ProjetBanque.Abstractions.Models
{
	public interface ICompte
	{
		IBanque Banque { get; set; }
		IClient Client { get; set; }
		string NumeroCompte { get; }
		double Solde { get; }

		double Crediter(double montant);
		double? Debiter(double montant);
	}
}