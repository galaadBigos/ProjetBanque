using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Moq;
using ProjetBanque.Abstractions;
using ProjetBanque.Abstractions.DAO;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.Data;
using ProjetBanque.dto;
using ProjetBanque.Models.Clients;
using ProjetBanque.Models.Comptes;
using ProjetBanque.Services;

namespace ProjetBanque.UnitTests.Services;

[TestClass]
public class BanqueServiceTest
{
    private Fixture _fixture = new();
    private Mock<IBanqueDAO> _banqueDaoMock;
    private BanqueService _banqueService;

    [TestInitialize]
    public void TestInitialize()
    {
        _banqueDaoMock = new Mock<IBanqueDAO>();

        _banqueService = new BanqueService(_banqueDaoMock.Object);
    }

    [TestMethod]
    [DataRow("LGBD0")]
    [DataRow("LGBD1")]
    [DataRow("LGBD2")]
    public void RecupererClientsDTO_VerificationSiRecupererClientsAppel(string nomBanque)
    {
        // Arrange
        _fixture.Customizations.Add(new TypeRelay(typeof(IClient), typeof(Client)));
        _banqueDaoMock.Setup(b => b.RecupererClients(nomBanque))
            .Returns(_fixture.CreateMany<IClient>().ToList());

        // Act
        _banqueService.RecupererClientsDTO(nomBanque);

        // Assert
        _banqueDaoMock.Verify(b => b.RecupererClients(nomBanque), Times.Once);
    }

    [TestMethod]
    [DataRow("LGBD0")]
    [DataRow("LGBD1")]
    [DataRow("LGBD2")]
    public void RecupererComptesDTO_VerificationSiRecupererComptesAppel(string nomBanque)
    {
        // Arrange
        _fixture.Customizations.Add(new TypeRelay(typeof(ICompte), typeof(Compte)));
        _banqueDaoMock.Setup(b => b.RecupererComptes(nomBanque))
            .Returns(_fixture.CreateMany<ICompte>().ToList());

        // Act
        _banqueService.RecupererComptesDTO(nomBanque);

        // Assert
        _banqueDaoMock.Verify(b => b.RecupererComptes(nomBanque), Times.Once);
    }

    [TestMethod]
    [DataRow("LGBD0", "C01210")]
    [DataRow("LGBD1", "C01211")]
    [DataRow("LGBD2", "C01512")]
    public void RecupererComptesDTOParClient_VerificationSiRecupererComptesParClientAppel(
        string nomBanque, string numeroClient)
    {
        // Act
        _banqueService.RecupererComptesDTOParClient(nomBanque, numeroClient);

        // Assert
        _banqueDaoMock.Verify(b => b.RecupererComptesParClient(nomBanque, numeroClient), Times.Once);
    }
}