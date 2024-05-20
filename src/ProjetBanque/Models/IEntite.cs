using ProjetBanque.Abstractions.DTO;
using ProjetBanque.Abstractions.Models;

namespace ProjetBanque.Models
{
    public abstract class IEntite : IEntity
    {
        public abstract IDTO ConvertirEnDTO();
    }
}