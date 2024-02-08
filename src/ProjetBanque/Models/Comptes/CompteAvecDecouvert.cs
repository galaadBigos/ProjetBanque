namespace ProjetBanque.Models.Comptes
{
	public class CompteAvecDecouvert(string numeroCompte, double decouvertAutorise) : Compte(numeroCompte)
	{
		public double DecouvertAutorise { get; set; } = decouvertAutorise;
		public override double? Debiter(double montant)
		{
			if (EstDebitable(montant))
				return Solde -= montant;

			return null;
		}

		private bool EstDebitable(double montant)
			=> Solde - montant >= 0 - DecouvertAutorise;
	}
}
