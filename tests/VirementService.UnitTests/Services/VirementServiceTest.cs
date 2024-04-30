using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProjetBanque.Abstractions.DAO;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.Data;
using VirementService.Controllers;

namespace VirementService.UnitTests.Services
{
    [TestClass]
    public class VirementControllerTests
    {
        [TestMethod]
        public void VirementInterne_WithSameBank_ShouldReturnBadRequest()
        {
            // Arrange
            var mockDataBase = new Mock<IDataBase>();
            var mockCompte = new Mock<ICompte>();

            mockDataBase.Setup(d => d.RecupererComptes("LGBD0"))
                        .Returns(new List<ICompte> { mockCompte.Object });

            var controller = new VirementController(mockDataBase.Object);

            // Act
            var result = controller.VirementInterne("LGBD0", "LGBD0", "1250", "1260", 100.0);

            // Assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void VirementInterne_WithSameBanks_ReturnsOk()
        {
            // Arrange
            var dataBaseMock = new Mock<IDataBase>();
            var controller = new VirementController(new DbFake());
            var compteDebiteur = new Mock<ICompte>();
            var compteCrediteur = new Mock<ICompte>();

            dataBaseMock.Setup(db => db.RecupererComptes("LGBD0"))
                .Returns(new List<ICompte>
                {
                    compteDebiteur.Object,
                    compteCrediteur.Object
                });

            compteDebiteur.Setup(cd => cd.Debiter(It.IsAny<double>()));
            compteCrediteur.Setup(cc => cc.Crediter(It.IsAny<double>()));

            // Act
            var result = controller.VirementInterne("LGBD0", "LGBD0", "1250", "1260", 100.0);

            // Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().Be("Le virement a bien été effectuée");
        }

        [TestMethod]
        public void VirementExterne_WithSameBanks_ReturnsOk()
        {
            // Arrange
            var dataBaseMock = new Mock<IDataBase>();
            var controller = new VirementController(new DbFake());
            var compteDebiteur = new Mock<ICompte>();
            var compteCrediteur = new Mock<ICompte>();

            dataBaseMock.Setup(db => db.RecupererComptes("LGBD0"))
                .Returns(new List<ICompte>
                {
                    compteDebiteur.Object,
                    compteCrediteur.Object
                });

            compteDebiteur.Setup(cd => cd.Debiter(It.IsAny<double>()));
            compteCrediteur.Setup(cc => cc.Crediter(It.IsAny<double>()));

            // Act
            var result = controller.VirementExterne("LGBD0", "LGBD2", "1250", "1262", 100.0);

            // Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().Be("Le virement a bien été effectuée");
        }
    }
}
