namespace ProjetBanque.Abstractions
{
    public interface IDAO<T>
    {
        public T ConvertToDTO(T entity);
    }
}
