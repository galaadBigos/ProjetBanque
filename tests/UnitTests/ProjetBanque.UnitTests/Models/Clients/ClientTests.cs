using Moq;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.Models.Clients;

namespace ProjetBanque.UnitTests.Models.Clients
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        [DataRow("12345", "123 Rue de la Poste", "John Doe")]
        public void Constructor_SetsPropertiesCorrectly(string numeroClient, string adresse, string nom)
        {
            // Act
            var client = new Client(numeroClient, adresse, nom);

            // Assert
            Assert.AreEqual(numeroClient, client.NumeroClient);
            Assert.AreEqual(adresse, client.Adresse);
            Assert.AreEqual(nom, client.Nom);
        }

        [TestMethod]
        [DataRow("12345", "123 Rue de la Poste", "John Doe")]
        public void ComptesProperty_ComptesCanBeSetAndGet(string numeroClient, string adresse, string nom)
        {
            // Arrange
            var client = new Client(numeroClient, adresse, nom);

            var comptes = new List<ICompte>();

            for (int i = 0; i < 2; i++)
                comptes.Add(new Mock<ICompte>().Object);

            // Act
            client.Comptes = comptes;

            // Assert
            Assert.AreEqual(comptes, client.Comptes);
        }
    }
}