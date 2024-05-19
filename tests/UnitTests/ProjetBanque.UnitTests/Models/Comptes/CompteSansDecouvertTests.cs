using FluentAssertions;
using ProjetBanque.dto;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.UnitTests.Models.Comptes;

[TestClass]
public class CompteSansDecouvertTests
{
    private readonly double _soldeInitial = 1000.0d;
    private readonly CompteSansDecouvert _compte = new("A001");

    [TestInitialize]
    public void Init()
    {
        _compte.Solde = _soldeInitial;
    }

    [TestMethod]
    public void ConvertirEnDTO_RetourneCompteAvecDecouvertDTO()
    {
        CompteSansDecouvertDTO dto = _compte.ConvertirEnDTO();

        dto.Should().NotBeNull();
        dto.Solde.Should().Be(_compte.Solde);
        dto.NumeroCompte.Should().Be(_compte.NumeroCompte);
    }

    [TestMethod]
    [DataRow(50.0d)]
    [DataRow(900.0d)]
    [DataRow(1000.0d)]
    public void Debiter_SoldePermetDebit_RetourneSoldeMisAJour(double montant)
    {
        if (montant > _soldeInitial)
            Assert.Inconclusive("Le montant est supérieurs au solde initial donc impossible de faire le test.");

        double? nouveauSolde = _compte.Debiter(montant);

        nouveauSolde.Should().NotBeNull();
        nouveauSolde.Should().Be(_soldeInitial - montant);
        nouveauSolde.Should().BeGreaterOrEqualTo(0);
    }

    [TestMethod]
    [DataRow(50.0d, 10.26d)]
    [DataRow(650.0d, 84.85d)]
    [DataRow(900.0d, 100.0d)]
    public void Debiter_SoldePermetDebitDeuxFois_RetourneSoldeMisAJour(
        double montant1, double montant2)
    {
        if ((montant1 + montant2) > _soldeInitial)
            Assert.Inconclusive(
                "Les montants sont supérieurs au solde initial et au decouvert autorisé donc impossible de faire le test.");

        _compte.Debiter(montant1);
        double? nouveauSolde = _compte.Debiter(montant2);

        nouveauSolde.Should().NotBeNull();
        nouveauSolde.Should().Be(_soldeInitial - montant1 - montant2);
        nouveauSolde.Should().BeGreaterOrEqualTo(0);
    }

    [TestMethod]
    [DataRow(1600.0d)]
    [DataRow(2000.0d)]
    [DataRow(50000.0d)]
    public void Debiter_SoldeNePermetPasDebit_RetourneNull(double montant)
    {
        if (montant <= _soldeInitial)
            Assert.Inconclusive("Le montant est inférieur ou égal au solde initial donc impossible de faire le test.");

        double? nouveauSolde = _compte.Debiter(montant);

        nouveauSolde.Should().BeNull();
    }
}