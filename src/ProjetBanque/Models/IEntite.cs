using ProjetBanque.Abstractions.DTO;

namespace ProjetBanque.Models
{
    public abstract class IEntite
    {
        public abstract IDTO ConvertirEnDTO();
    }
}
