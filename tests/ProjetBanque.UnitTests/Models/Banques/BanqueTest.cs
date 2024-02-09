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
        [DataRow("123456789", "Metz", "John Doe", "987654321", 500)]
        [DataRow("123", "M", "John", "987", 8000)]
        public void Retrait_VerificationSiRetraitAppelDebiter_DebiterEffectue(
            string clientNumero, string clientAdresse, string clientNom, string compteNumero, double montant)
        {
            // Arrange
            Banque banque = new();

            Client client = new(clientNumero, clientAdresse, clientNom);
            Mock<Compte> compteMock = new(compteNumero);

            client.Comptes.Add(compteMock.Object);
            banque.Clients.Add(client);

            // Act
            banque.Retrait(compteNumero, clientNom, montant);

            // Assert
            compteMock.Verify(c => c.Debiter(montant), Times.Once);
        }

        [TestMethod]
        [DataRow("123456789", "Metz", "John Doe", "987654321", 500)]
        [DataRow("123", "M", "John", "987", 8000)]
        public void Depot_DeposeXArgentSurUnCompte_MontantDeposerEgalMontantEtSoldePlusX(
            string clientNumero, string clientAdresse, string clientNom, string compteNumero, double montant)
        {
            // Arrange
            Banque banque = new();

            Client client = new(clientNumero, clientAdresse, clientNom);
            Mock<Compte> compteMock = new(compteNumero);

            client.Comptes.Add(compteMock.Object);
            banque.Clients.Add(client);

            double soldeOrigine = compteMock.Object.Solde;

            // Act
            double? montantDeposer = banque.Depot(compteNumero, clientNom, montant);

            // Assert
            montantDeposer.Should().Be(montant);
            compteMock.Object.Solde.Should().Be(soldeOrigine + montant);
        }

        [TestMethod]
        [DataRow("123456789", "Metz", "John Doe", "987654321", 500, "987654322")]
        public void Depot_DemandeDepotSurCompteInexistant_RetourneNull(
            string clientNumero, string clientAdresse, string clientNom, string compteNumero, double montant, string compteInexistant
        )
        {
            // Arrange
            Banque banque = new();

            Client client = new(clientNumero, clientAdresse, clientNom);
            Mock<Compte> compteMock = new(compteNumero);

            client.Comptes.Add(compteMock.Object);
            banque.Clients.Add(client);

            // Act
            double? montantDeposer = banque.Depot("987654322", clientNom, montant);

            // Assert
            montantDeposer.Should().BeNull();
        }

        [TestMethod]
        [DataRow("123456789", "Metz", "John Doe", "987654321", 500, "Bob")]
        public void Depot_DemandeDepotSurClientInexistant_RetourneNull(
            string clientNumero, string clientAdresse, string clientNom, string compteNumero, double montant, string clientInexistant
        )
        {
            // Arrange
            Banque banque = new();

            Client client = new(clientNumero, clientAdresse, clientNom);
            Mock<Compte> compteMock = new(compteNumero);

            client.Comptes.Add(compteMock.Object);
            banque.Clients.Add(client);

            // Act
            double? montantDeposer = banque.Depot(compteNumero, clientInexistant, montant);

            // Assert
            montantDeposer.Should().BeNull();
        }
    }
}
