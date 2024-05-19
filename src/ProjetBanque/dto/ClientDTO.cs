using ProjetBanque.Abstractions.DTO;

namespace ProjetBanque.dto
{
    public class ClientDTO : IDTO
    {
        public string NumeroClient { get; set; }
        public string Adresse { get; set; }
        public string Nom { get; set; }
        public List<CompteDTO> Comptes { get; set; }
    }
}