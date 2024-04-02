using AutoFixture;
using FluentAssertions;
using Moq;
using ProjetBanque.Abstractions;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.Models.Banques;

namespace ProjetBanque.UnitTests.Models.Banques
{
	[TestClass]
	public class BanqueTests
	{
		private readonly Fixture _fixture = new();
		private readonly Banque _banque = new();
		private readonly Mock<IClient> _clientMock = new();
		private readonly Mock<ICompte> _compteMock = new();

		[TestInitialize]
		public void TestInitialize()
		{
			InitialisationClientMock();
			InitialisationCompteMock();

			_clientMock.Setup(c => c.Comptes).Returns([_compteMock.Object]);
			_banque.Clients.Add(_clientMock.Object);
		}

		private void InitialisationClientMock()
		{
			_clientMock.Setup(c => c.NumeroClient).Returns(_fixture.Create<string>());
			_clientMock.Setup(c => c.Adresse).Returns(_fixture.Create<string>());
			_clientMock.Setup(c => c.Nom).Returns(_fixture.Create<string>());
		}

		private void InitialisationCompteMock()
		{
			_compteMock.Setup(c => c.NumeroCompte).Returns(_fixture.Create<string>());
		}

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
		[DataRow(500d)]
		[DataRow(8000d)]
		public void Retrait_VerificationSiRetraitAppelDebiter_DebiterEffectue(double montant)
		{
			// Arrange
			string compteNumero = _compteMock.Object.NumeroCompte;
			string clientNom = _clientMock.Object.Nom;

			// Act
			_banque.Retrait(compteNumero, clientNom, montant);

			// Assert
			_compteMock.Verify(c => c.Debiter(montant), Times.Once);
		}

		[TestMethod]
		[DataRow(500d)]
		[DataRow(8000d)]
		public void Depot_DeposeXArgentSurUnCompte_RetourneSoldePlusX(double montant)
		{
			// Arrange
			string compteNumero = _compteMock.Object.NumeroCompte;
			string clientNom = _clientMock.Object.Nom;

			// Act
			_banque.Depot(compteNumero, clientNom, montant);

			// Assert
			_compteMock.Verify(c => c.Crediter(montant), Times.Once);
		}

		[TestMethod]
		[DataRow(500d)]
		[DataRow(8000d)]
		public void Depot_DemandeDepotSurCompteInexistant_RetourneNull(double montant)
		{
			// Arrange
			string compteNumero = _compteMock.Object.NumeroCompte;
			string clientNom = _clientMock.Object.Nom;

			string compteNumeroInexistant;

			do
			{
				compteNumeroInexistant = _fixture.Create<string>();
			} while (compteNumeroInexistant == compteNumero);

			// Act
			double? montantDeposer = _banque.Depot(compteNumeroInexistant, clientNom, montant);

			// Assert
			_compteMock.Verify(c => c.Crediter(montant), Times.Never);
			montantDeposer.Should().BeNull();
		}

		[TestMethod]
		[DataRow(500d)]
		[DataRow(8000d)]
		public void Depot_DemandeDepotSurClientInexistant_RetourneNull(double montant)
		{
			// Arrange
			string compteNumero = _compteMock.Object.NumeroCompte;
			string clientNom = _clientMock.Object.Nom;

			string clientNomInexistant;

			do
			{
				clientNomInexistant = _fixture.Create<string>();
			} while (clientNomInexistant == clientNom);

			// Act
			double? montantDeposer = _banque.Depot(compteNumero, clientNomInexistant, montant);

			// Assert
			_compteMock.Verify(c => c.Crediter(montant), Times.Never);
			montantDeposer.Should().BeNull();
		}
	}
}
