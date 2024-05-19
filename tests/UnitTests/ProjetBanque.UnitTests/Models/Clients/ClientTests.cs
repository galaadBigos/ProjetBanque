using Moq;
using ProjetBanque.Abstractions.Models;
using ProjetBanque.dto;
using ProjetBanque.Models.Clients;

namespace ProjetBanque.UnitTests.Models.Clients
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        [DataRow("12345", "123 Rue de la Poste", "John Doe")]
        public void Constructor_SetsPropertiesCorrectly(string numeroClient, string adresse, string nom)
        {
            Client client = new(numeroClient, adresse, nom);

            Assert.AreEqual(numeroClient, client.NumeroClient);
            Assert.AreEqual(adresse, client.Adresse);
            Assert.AreEqual(nom, client.Nom);
        }

        [TestMethod]
        [DataRow("12345", "123 Rue de la Poste", "John Doe")]
        public void ComptesProperty_ComptesCanBeSetAndGet(string numeroClient, string adresse, string nom)
        {
            Client client = new(numeroClient, adresse, nom);

            List<ICompte> comptes = new();

            for (int i = 0; i < 2; i++)
                comptes.Add(new Mock<ICompte>().Object);

            client.Comptes = comptes;

            Assert.AreEqual(comptes, client.Comptes);
        }

        [TestMethod]
        [DataRow("12345", "123 Rue de la Poste", "John Doe")]
        public void ConvertirEnDTO_ReturnClientDTO(string numeroClient, string adresse, string nom)
        {
            Client client = new(numeroClient, adresse, nom);

            // ReSharper disable once SuggestVarOrType_SimpleTypes
            ClientDTO clientDto = client.ConvertirEnDTO();

            Assert.AreEqual(numeroClient, clientDto.NumeroClient);
            Assert.AreEqual(adresse, clientDto.Adresse);
            Assert.AreEqual(nom, clientDto.Nom);
        }
    }
}