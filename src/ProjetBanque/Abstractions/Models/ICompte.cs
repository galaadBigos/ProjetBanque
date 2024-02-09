namespace ProjetBanque.Abstractions.Models
{
	public interface ICompte : IEntity
	{
		string NumeroCompte { get; }
		double Solde { get; }

		double Crediter(double montant);
		double? Debiter(double montant);
	}
}