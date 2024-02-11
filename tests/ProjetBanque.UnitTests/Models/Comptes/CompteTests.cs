using FluentAssertions;
using Moq;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.UnitTests.Models.Comptes;

[TestClass]
public class CompteTests
{
    private readonly Mock<Compte> _compte = new("A001");

    [TestMethod]
    [DataRow(50.0d)]
    [DataRow(250.0d)]
    public void Crediter_SoldeInitial0_RetourneSoldeMisAJour(double montant)
    {
        // Act
        double nouvelleSolde = _compte.Object.Crediter(montant);

        // Assert
        nouvelleSolde.Should().Be(montant);
    }
}
