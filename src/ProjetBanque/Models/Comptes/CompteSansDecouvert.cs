namespace ProjetBanque.Models.Comptes
{
	public class CompteSansDecouvert(string numeroCompte) : Compte(numeroCompte)
	{
		public override double? Debiter(double montant)
			=> Solde -= montant;
	}
}
