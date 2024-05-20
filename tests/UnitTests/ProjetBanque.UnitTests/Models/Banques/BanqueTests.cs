using AutoFixture;
using FluentAssertions;
using Moq;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.Models.Banques;

namespace ProjetBanque.UnitTests.Models.Banques;

[TestClass]
public class BanqueTests
{
    private readonly int _soldeInitial = 1000;
    private readonly Fixture _fixture = new();
    private readonly Banque _banque = new();
    private readonly Mock<IClient> _clientMock = new();
    private readonly Mock<ICompte> _compteMock = new();

    [TestInitialize]
    public void TestInitialize()
    {
        InitialisationCompteMock();
        InitialisationClientMock();

        _banque.Nom = "MaBanque";
        _banque.Comptes.Add(_compteMock.Object);
        _banque.Clients.Add(_clientMock.Object);
    }

    private void InitialisationCompteMock()
    {
        _compteMock.Setup(c => c.NumeroCompte).Returns(_fixture.Create<string>());
        _compteMock.Setup(c => c.Solde).Returns(_soldeInitial);
    }

    private void InitialisationClientMock()
    {
        _clientMock.Setup(c => c.NumeroClient).Returns(_fixture.Create<string>());
        _clientMock.Setup(c => c.Adresse).Returns(_fixture.Create<string>());
        _clientMock.Setup(c => c.Nom).Returns(_fixture.Create<string>());
        _clientMock.Setup(c => c.Comptes).Returns([_compteMock.Object]);
    }

    [TestMethod]
    public void ConstructeurVide_ClientsEtComptesSontListesVides()
    {
        Banque banque = new Banque();

        banque.Nom.Should().BeEmpty();
        banque.Clients.Should().HaveCount(0);
        banque.Comptes.Should().HaveCount(0);
    }

    [TestMethod]
    [DataRow(500d)]
    [DataRow(8000d)]
    public void Depot_DeposeXArgentSurUnCompte_RetourneSoldePlusX(double montant)
    {
        string clientNom = _clientMock.Object.Nom;
        string compteNumero = _compteMock.Object.NumeroCompte;

        _compteMock.Setup(c => c.Crediter(montant)).Returns(_soldeInitial + montant);

        double? nouveauSolde = _banque.Depot(compteNumero, clientNom, montant);

        _compteMock.Verify(c => c.Crediter(montant), Times.Once);
        nouveauSolde.Should().Be(_soldeInitial + montant);
    }

    [TestMethod]
    [DataRow(500d)]
    [DataRow(8000d)]
    public void Depot_DemandeDepotSurCompteInexistant_RetourneNull(double montant)
    {
        string compteNumero = _compteMock.Object.NumeroCompte;
        string clientNom = _clientMock.Object.Nom;

        string compteNumeroInexistant;
        do
        {
            compteNumeroInexistant = _fixture.Create<string>();
        } while (compteNumeroInexistant == compteNumero);

        double? montantDeposer = _banque.Depot(compteNumeroInexistant, clientNom, montant);

        _compteMock.Verify(c => c.Crediter(montant), Times.Never);
        montantDeposer.Should().BeNull();
    }

    [TestMethod]
    [DataRow(500d)]
    [DataRow(8000d)]
    public void Depot_DemandeDepotSurClientInexistant_RetourneNull(double montant)
    {
        string compteNumero = _compteMock.Object.NumeroCompte;
        string clientNom = _clientMock.Object.Nom;

        string clientNomInexistant;

        do
        {
            clientNomInexistant = _fixture.Create<string>();
        } while (clientNomInexistant == clientNom);

        double? montantDeposer = _banque.Depot(compteNumero, clientNomInexistant, montant);

        _compteMock.Verify(c => c.Crediter(montant), Times.Never);
        montantDeposer.Should().BeNull();
    }

    [TestMethod]
    [DataRow(500d)]
    [DataRow(8000d)]
    public void Retrait_VerificationSiRetraitAppelDebiter_DebiterEffectue(double montant)
    {
        string clientNom = _clientMock.Object.Nom;
        string compteNumero = _compteMock.Object.NumeroCompte;

        _compteMock.Setup(c => c.Debiter(montant)).Returns(_soldeInitial - montant);

        double? nouveauSolde = _banque.Retrait(compteNumero, clientNom, montant);

        _compteMock.Verify(c => c.Debiter(montant), Times.Once);
        nouveauSolde.Should().Be(_soldeInitial - montant);
    }
}