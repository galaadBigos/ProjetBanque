using ProjetBanque.dto;

namespace ProjetBanque.Models.Comptes;

public class CompteAvecDecouvert(string numeroCompte, double decouvertAutorise) : Compte(numeroCompte)
{
    public double DecouvertAutorise { get; set; } = decouvertAutorise;

    public override CompteAvecDecouvertDTO ConvertirEnDTO()
    {
        return new CompteAvecDecouvertDTO
        {
            Solde = Solde,
            NumeroCompte = NumeroCompte,
            DecouvertAutorise = DecouvertAutorise,
        };
    }

    public override double? Debiter(double montant)
    {
        if (EstDebitable(montant))
            return Solde -= montant;

        return null;
    }

    private bool EstDebitable(double montant)
        => Solde - montant >= 0 - DecouvertAutorise;
}