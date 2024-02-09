using FluentAssertions;
using Moq;
using ProjetBanque.Abstractions;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.Models.Banques;

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
			List<IClient> clients = banque.Clients;
			List<ICompte> comptes = banque.Comptes;

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

			Mock<IClient> client = new(clientNumero, clientAdresse, clientNom);
			Mock<ICompte> compteMock = new(compteNumero);

			client.Object.Comptes.Add(compteMock.Object);
			banque.Clients.Add(client.Object);

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

			Mock<IClient> client = new(clientNumero, clientAdresse, clientNom);
			Mock<ICompte> compteMock = new(compteNumero);

			client.Object.Comptes.Add(compteMock.Object);
			banque.Clients.Add(client.Object);

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

			Mock<IClient> client = new(clientNumero, clientAdresse, clientNom);
			Mock<ICompte> compteMock = new(compteNumero);

			client.Object.Comptes.Add(compteMock.Object);
			banque.Clients.Add(client.Object);

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

			Mock<IClient> client = new(clientNumero, clientAdresse, clientNom);
			Mock<ICompte> compteMock = new(compteNumero);

			client.Object.Comptes.Add(compteMock.Object);
			banque.Clients.Add(client.Object);

			// Act
			double? montantDeposer = banque.Depot(compteNumero, clientInexistant, montant);

			// Assert
			montantDeposer.Should().BeNull();
		}
	}
}
