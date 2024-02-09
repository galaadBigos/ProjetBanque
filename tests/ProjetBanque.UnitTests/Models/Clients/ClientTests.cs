namespace ProjetBanque.UnitTests.Clients
{
	using global::ProjetBanque.Abstractions.Models;
	using global::ProjetBanque.Models.Clients;
	using global::ProjetBanque.Models.Comptes;

	namespace ProjetBanque.Models.Clients.Tests
	{
		[TestClass]
		public class ClientTests
		{
			[TestMethod]
			public void Constructor_SetsPropertiesCorrectly()
			{
				// Arrange
				string numeroClient = "12345";
				string adresse = "123 Rue de la Poste";
				string nom = "John Doe";

				// Act
				var client = new Client(numeroClient, adresse, nom);

				// Assert
				Assert.AreEqual(numeroClient, client.NumeroClient);
				Assert.AreEqual(adresse, client.Adresse);
				Assert.AreEqual(nom, client.Nom);
			}

			[TestMethod]
			public void ComptesProperty_CanBeSetAndGet()
			{
				// Arrange
				var client = new Client("12345", "123 Rue de la Poste", "John Doe");
				var compte1 = new CompteSansDecouvert("test1");
				var compte2 = new CompteSansDecouvert("test2");
				var comptes = new List<ICompte> { compte1, compte2 };

				// Act
				client.Comptes = comptes;

				// Assert
				Assert.AreEqual(comptes, client.Comptes);
			}
		}
	}

}
