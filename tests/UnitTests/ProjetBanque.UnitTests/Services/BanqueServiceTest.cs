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
    public void RecupererClientsDTO_VerificationSiRecupererListClientsDtoSelonNomBanque(string nomBanque)
    {
        _banqueDaoMock.Setup(b => b.RecupererClients(nomBanque)).Returns([
            new Client("C0121x", "adresse x", "nom x"),
            new Client("C0121y", "adresse y", "nom y"),
            new Client("C0121z", "adresse z", "nom z"),
        ]);

        List<ClientDTO> resultat = _banqueService.RecupererClientsDTO(nomBanque);

        _banqueDaoMock.Verify(b => b.RecupererClients(nomBanque), Times.Once);
        resultat.Should().HaveCount(3);
    }

    [TestMethod]
    [DataRow("LGBD0")]
    [DataRow("LGBD1")]
    [DataRow("LGBD2")]
    public void RecupererComptesDTO_VerificationSiRecupererListComptesDtoSelonNomBanque(string nomBanque)
    {
        _banqueDaoMock.Setup(b => b.RecupererComptes(nomBanque)).Returns([
            new CompteAvecDecouvert("125x", 50),
            new CompteSansDecouvert("125y")
        ]);

        List<CompteDTO> resultat = _banqueService.RecupererComptesDTO(nomBanque);

        _banqueDaoMock.Verify(b => b.RecupererComptes(nomBanque), Times.Once);
        resultat.Should().HaveCount(2);
    }

    [TestMethod]
    [DataRow("LGBD0", "C01210")]
    [DataRow("LGBD1", "C01211")]
    [DataRow("LGBD2", "C01512")]
    public void RecupererComptesDTOParClient_VerificationSiRecupererListComptesDtoSelonNomBanqueEtNumeroClient(
        string nomBanque, string numeroClient)
    {
        _banqueDaoMock.Setup(b => b.RecupererComptesParClient(nomBanque, numeroClient)).Returns([
            new CompteAvecDecouvert("125x", 50),
            new CompteSansDecouvert("125y")
        ]);

        List<CompteDTO>? resultat = _banqueService.RecupererComptesDTOParClient(nomBanque, numeroClient);

        _banqueDaoMock.Verify(b => b.RecupererComptesParClient(nomBanque, numeroClient), Times.Once);
        resultat.Should().HaveCount(2);
    }
}