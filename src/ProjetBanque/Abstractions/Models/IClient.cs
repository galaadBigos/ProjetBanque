namespace ProjetBanque.Abstractions.Models
{
    public interface IClient : IEntity
    {
        string NumeroClient { get; set; }
        string Adresse { get; set; }
        string Nom { get; set; }
        List<ICompte> Comptes { get; set; }
    }
}