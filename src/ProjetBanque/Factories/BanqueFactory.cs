using ProjetBanque.Abstractions.Models;
using ProjetBanque.Models.Banques;

namespace ProjetBanque.Factories
{
	public class BanqueFactory
	{
		public static IBanque RecupererInstance()
		{
			Banque result = new();



			return result;
		}
	}
}
