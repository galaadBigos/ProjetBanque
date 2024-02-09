using ProjetBanque.Abstractions;

namespace ProjetBanque.Repositories.Abstractions
{
	public interface IBanqueRepository
	{
		IBanque RecupererBanques();
	}
}
