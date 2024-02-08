using FluentAssertions;
using ProjetBanque.Models.Banques;
using ProjetBanque.Models.Clients;
using ProjetBanque.Models.Comptes;
using Moq;

namespace ProjetBanqueTest.UnitTests.Models.BanqueTests
{
    [TestClass]
    public class BanqueTest
    {
        [TestMethod]
        public void ConstructeurVide_ClientsEtComptesSontListesVides()
        {
            // Arrange
            Banque banque = new Banque();

            // Act
            List<Client> clients = banque.Clients;
            List<Compte> comptes = banque.Comptes;

            // Assert
            clients.Should().HaveCount(0);
            comptes.Should().HaveCount(0);
        }

        [TestMethod]
        public void Retrait_CompteExistantEtClientExistant_RetraitEffectue()
        {
            // Arrange
            Banque banque = new();

            Client client = new("123456789", "Metz", "John Doe");
            Mock<Compte> compteMock = new("123456789");

            client.Comptes.Add(compteMock.Object);
            banque.Clients.Add(client);

            // Act
            banque.Retrait("123456789", "John Doe", 500);

            // Assert
            compteMock.Verify(c => c.Debiter(500), Times.Once);
        }
    }
}
