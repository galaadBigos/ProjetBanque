using ProjetBanque.dto;

namespace ProjetBanque.Models.Comptes
{
	public class CompteSansDecouvert(string numeroCompte) : Compte(numeroCompte)
	{
        public override DTO ConvertirEnDTO()
        {
            throw new NotImplementedException();
        }

        public override double? Debiter(double montant)
			=> Solde -= montant;
	}
}
