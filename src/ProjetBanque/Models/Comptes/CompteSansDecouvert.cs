using ProjetBanque.Abstractions.DTO;
using ProjetBanque.dto;

namespace ProjetBanque.Models.Comptes
{
	public class CompteSansDecouvert(string numeroCompte) : Compte(numeroCompte)
	{
		public override IDTO ConvertirEnDTO()
		{
			return new CompteSansDecouvertDTO
			{
				Solde = Solde,
				NumeroCompte = NumeroCompte,
			};
		}

		public override double? Debiter(double montant)
			=> Solde -= montant;
	}
}
