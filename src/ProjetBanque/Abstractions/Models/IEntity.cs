using ProjetBanque.Abstractions.DTO;

namespace ProjetBanque.Abstractions.Models
{
    public interface IEntity
    {
        IDTO ConvertirEnDTO();
    }
}