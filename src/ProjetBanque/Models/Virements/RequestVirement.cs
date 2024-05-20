using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Models.Virements
{
    public class RequestVirement : IRequestVirement
    {
        public string NomBanqueDebiteur { get; set; }
        public string NomBanqueCrediteur { get; set; }
        public string NumeroCompteDebiteur { get; set; }
        public string NumeroCompteCrediteur { get; set; }
        public double Somme { get; set; }
    }
}