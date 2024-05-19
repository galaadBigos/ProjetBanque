using FluentAssertions;
using ProjetBanque.dto;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.UnitTests.Models.Comptes;

[TestClass]
public class CompteAvecDecouvertTests
{
    private readonly double _soldeInitial = 1000.0d;
    private readonly CompteAvecDecouvert _compte = new("A001", 500.0d);

    [TestInitialize]
    public void Init()
    {
        _compte.Solde = _soldeInitial;
    }

    [TestMethod]
    public void ConvertirEnDTO_RetourneCompteAvecDecouvertDTO()
    {
        CompteAvecDecouvertDTO dto = _compte.ConvertirEnDTO();

        dto.Should().NotBeNull();
        dto.Solde.Should().Be(_compte.Solde);
        dto.NumeroCompte.Should().Be(_compte.NumeroCompte);
        dto.DecouvertAutorise.Should().Be(_compte.DecouvertAutorise);
    }

    [TestMethod]
    [DataRow(50.0d)]
    [DataRow(900.0d)]
    [DataRow(1000.0d)]
    public void Debiter_SoldePermetDebit_RetourneSoldeMisAJourEnPositif(double montant)
    {
        if (montant > _soldeInitial)
            Assert.Inconclusive("Le montant est supérieurs au solde initial donc impossible de faire le test.");

        double? nouveauSolde = _compte.Debiter(montant);

        nouveauSolde.Should().NotBeNull();
        nouveauSolde.Should().Be(_soldeInitial - montant);
        nouveauSolde.Should().BeGreaterOrEqualTo(0);
    }

    [TestMethod]
    [DataRow(1000.1d)]
    [DataRow(1250.0d)]
    [DataRow(1500.0d)]
    public void Debiter_SoldePermetDebit_RetourneSoldeMisAJourEnNegatif(double montant)
    {
        if (montant < _soldeInitial || montant > (_soldeInitial + _compte.DecouvertAutorise))
            Assert.Inconclusive("Le montant ne permet pas de tester le découvert autorisé.");

        double? nouveauSolde = _compte.Debiter(montant);

        nouveauSolde.Should().NotBeNull();
        nouveauSolde.Should().Be(_soldeInitial - montant);
        nouveauSolde.Should().BeNegative();
    }

    [TestMethod]
    [DataRow(500.0d, 100.26d)]
    [DataRow(950.0d, 84.85d)]
    [DataRow(1100.0d, 2.36d)]
    public void Debiter_SoldePermetDebitDeuxFoisMemeEnNegatifEtRespectLeDecouvert_RetourneSoldeMisAJour(
        double montant1, double montant2)
    {
        if ((montant1 + montant2) > (_soldeInitial + _compte.DecouvertAutorise))
            Assert.Inconclusive(
                "Les montants sont supérieurs au solde initial et au decouvert autorisé donc impossible de faire le test.");

        _compte.Debiter(montant1);
        double? nouveauSolde = _compte.Debiter(montant2);

        nouveauSolde.Should().NotBeNull();
        nouveauSolde.Should().Be(_soldeInitial - montant1 - montant2);
    }

    [TestMethod]
    [DataRow(1600.0d)]
    [DataRow(2000.0d)]
    [DataRow(50000.0d)]
    public void Debiter_SoldeNePermetPasDebit_RetourneNull(double montant)
    {
        if (montant <= (_soldeInitial + _compte.DecouvertAutorise))
            Assert.Inconclusive("Le montant est inférieur ou égal au solde initial donc impossible de faire le test.");

        double? nouveauSolde = _compte.Debiter(montant);

        nouveauSolde.Should().BeNull();
    }
}