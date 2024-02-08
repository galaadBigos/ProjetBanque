using ProjetBanque.Models.Banques;

namespace ProjetBanque.Models.Comptes
{
	public abstract class Compte(string numeroCompte)
	{
		public double Solde { get; protected set; } = 0;
		public string NumeroCompte { get; protected set; } = numeroCompte;

		public Banque Banque { get; set; }

		public abstract double? Debiter(double montant);

		public double Crediter(double montant)
			=> Solde += montant;
	}
}
