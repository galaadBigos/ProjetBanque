namespace ProjetBanque.Abstractions.Services
{
	public interface ISecuriteService
	{
		public string UserId { get; set; }
		bool EstAutorise(string token);
	}
}
