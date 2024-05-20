using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Models.Comptes;

public abstract class Compte(string numeroCompte) : IEntite, ICompte
{
    public string NumeroCompte { get; protected set; } = numeroCompte;
    public double Solde { get; set; } = 0;

    public double Crediter(double montant)
        => Solde += montant;

    public abstract double? Debiter(double montant);
}