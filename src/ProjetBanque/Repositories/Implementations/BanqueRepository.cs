using ProjetBanque.Abstractions;
using ProjetBanque.Factories;
using ProjetBanque.Repositories.Abstractions;

namespace ProjetBanque.Repositories.Implementations
{
	public class BanqueRepository : IBanqueRepository
	{
		public IBanque RecupererBanques()
			=> BanqueFactory.RecupererInstance();
	}
}
