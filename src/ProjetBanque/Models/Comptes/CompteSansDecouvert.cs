using ProjetBanque.dto;

namespace ProjetBanque.Models.Comptes;

public class CompteSansDecouvert(string numeroCompte) : Compte(numeroCompte)
{
    public override CompteSansDecouvertDTO ConvertirEnDTO()
    {
        return new CompteSansDecouvertDTO
        {
            Solde = Solde,
            NumeroCompte = NumeroCompte,
        };
    }

    public override double? Debiter(double montant)
    {
        if (Solde - montant < 0)
            return null;

        return Solde -= montant;
    }
}
