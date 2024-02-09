using ProjetBanque.Models.Banques;

namespace ProjetBanque.dto
{
    public abstract class CompteDTO : DTO
    {
        public double Solde { get; protected set; }
        public string NumeroCompte { get; protected set; }

        public Banque Banque { get; set; }

    }
}
