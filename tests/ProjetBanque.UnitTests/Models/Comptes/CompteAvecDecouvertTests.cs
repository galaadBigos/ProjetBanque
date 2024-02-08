using FluentAssertions;
using ProjetBanque.Models.Comptes;

namespace ProjetBanque.UnitTests.Models.Comptes
{
	[TestClass]
	public class CompteAvecDecouvertTests
	{
		private CompteAvecDecouvert _compte;

		[TestInitialize]
		public void Init()
		{
			_compte = new CompteAvecDecouvert("A001", 500.0d);
			_compte.Crediter(1000.0d);
		}

		[TestMethod]
		[DataRow(500.0d)]
		[DataRow(1000.0d)]
		[DataRow(1500.0d)]
		public void Debiter_SoldePermetDebit_RetourneSoldeMisAJour(double montant)
		{
			double precedentSolde = _compte.Solde;
			double? nouveauSolde = _compte.Debiter(montant);

			nouveauSolde.Should().NotBeNull();
			nouveauSolde.Should().Be(precedentSolde - montant);
		}

		[TestMethod]
		[DataRow(1600.0d)]
		[DataRow(2000.0d)]
		[DataRow(50000.0d)]
		public void Debiter_SoldeNePermetPasDebit_RetourneNull(double montant)
		{
			double? nouveauSolde = _compte.Debiter(montant);

			nouveauSolde.Should().BeNull();
		}
	}
}
