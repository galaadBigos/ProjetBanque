using ProjetBanque.Models.Clients;

namespace ProjetBanque.Data
{
	public class DbFake
	{
		public Client RecupererFakeClient()
			=> new Client("C0121", "13 rue de Metz", "Ludovic Wagner");
	}
}
