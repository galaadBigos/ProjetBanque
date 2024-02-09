using ProjetBanque.dto;

namespace ProjetBanque.Abstractions.Models
{
    public interface IEntity
    {
        public abstract DTO ConvertirEnDTO();

    }
}
