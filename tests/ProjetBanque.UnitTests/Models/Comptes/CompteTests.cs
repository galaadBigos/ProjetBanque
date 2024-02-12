using FluentAssertions;
using Moq;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.UnitTests.Models.Comptes;

[TestClass]
public class CompteTests
{
    private readonly Mock<Compte> _compteMock = new("A001");

    [TestMethod]
    [DataRow(50.0d)]
    [DataRow(250.0d)]
    public void Crediter_SoldeInitial0_RetourneSoldeMisAJour(double montant)
    {
        double soldeOrigine = _compteMock.Object.Solde;

        // Act
        double nouvelleSolde = _compteMock.Object.Crediter(montant);

        // Assert
        nouvelleSolde.Should().Be(soldeOrigine + montant);
        _compteMock.Object.Solde.Should().Be(nouvelleSolde);
    }
}
