using FluentAssertions;
using Moq;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.UnitTests.Models.Comptes;

[TestClass]
public class CompteTests
{
    private readonly Mock<Compte> _compteMock = new("A001");

    public void Constructeur_SoldeInitial0_RetourneSolde0()
    {
        _compteMock.Object.Solde.Should().Be(0);
    }

    [TestMethod]
    [DataRow(50.0d)]
    [DataRow(250.0d)]
    public void Crediter_SoldeInitial0EtCrediterUneFois_RetourneSoldeMisAJour(double montant)
    {
        double soldeOrigine = _compteMock.Object.Solde;

        double nouvelleSolde = _compteMock.Object.Crediter(montant);

        nouvelleSolde.Should().Be(soldeOrigine + montant);
        _compteMock.Object.Solde.Should().Be(nouvelleSolde);
    }

    [TestMethod]
    [DataRow(50.0d, 25.0d)]
    [DataRow(250.0d, 99.99d)]
    public void Crediter_SoldeInitial0EtCrediterDeuxFois_RetourneSoldeMisAJour(double montant1, double montant2)
    {
        double soldeOrigine = _compteMock.Object.Solde;

        _compteMock.Object.Crediter(montant1);
        double nouvelleSolde = _compteMock.Object.Crediter(montant2);

        nouvelleSolde.Should().Be(soldeOrigine + montant1 + montant2);
        _compteMock.Object.Solde.Should().Be(nouvelleSolde);
    }
}