using FluentAssertions;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.UnitTests.Models.Comptes
{
    [TestClass]
    public class CompteSansDecouvertTests
    {
        private CompteSansDecouvert _compte = new CompteSansDecouvert("A001");

        [TestInitialize]
        public void Init()
        {
            _compte.Crediter(1000.0d);
        }

        [TestMethod]
        [DataRow(500.0d)]
        [DataRow(4000.0d)]
        [DataRow(15000.0d)]
        public void Debiter_SoldePermetDebit_RetourneSoldeMisAJour(double montant)
        {
            double precedentSolde = _compte.Solde;
            double? nouveauSolde = _compte.Debiter(montant);

            nouveauSolde.Should().NotBeNull();
            nouveauSolde.Should().Be(precedentSolde - montant);
        }
    }
}