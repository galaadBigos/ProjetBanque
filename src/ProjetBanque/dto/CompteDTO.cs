using ProjetBanque.Abstractions.DTO;

namespace ProjetBanque.dto
{
    public abstract class CompteDTO : IDTO
    {
        public string NumeroCompte { get; set; }
        public double Solde { get; set; }
    }
}