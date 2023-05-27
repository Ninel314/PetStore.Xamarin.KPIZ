using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetstoreAPI.Api;
using PetstoreAPI.Data;
using PetstoreAPI.Services;
using System;
using System.Threading.Tasks;

namespace PetstoreAPI.Test
{
    [TestClass]
    public class PetStoreAPITests
    {
        private Mock<IPetApi> _petApiMock;
        private PetService _petService;

        public void Setup()
        {
            _petApiMock = new Mock<IPetApi>();
            _petService = new PetService(_petApiMock.Object);
        }

        [TestMethod]
        public async Task FindPetsByStatus_ValidData_ReturnsListOfSoldPets()
        {
            // ARRANGE
            var validStatus = "sold";
            var binanceServiceMock = new Mock<IPetService>();
            binanceServiceMock
                .Setup(service => service.FindPetsByStatus(validStatus))
                .Returns(Task.FromResult(
                    Response<Pet[]>.Success(new[]
                    {
                        new Pet(),
                        new Pet()
                    })));

            var viewModel = new MainPageViewModel(binanceServiceMock.Object);

            // ACT
            viewModel.Status = validStatus;
            await viewModel.InitAsync();

            // ASSERT
            Assert.AreEqual(2, viewModel.Pets.Length);
        }


        [TestMethod]
        public async Task FindPetsByStatus_InvalidData_ReturnsEmptyList()
        {
            // ARRANGE
            var invalidStatus = "any text";
            var binanceServiceMock = new Mock<IPetService>();
            binanceServiceMock
                .Setup(service => service.FindPetsByStatus(invalidStatus))
                .Returns(Task.FromResult(
                    Response<Pet[]>.Success(new Pet[0])));

            var viewModel = new MainPageViewModel(binanceServiceMock.Object);

            // ACT
            viewModel.Status = invalidStatus;

            await viewModel.InitAsync();

            // ASSERT
            Assert.AreEqual(0, viewModel.Pets.Length);
        }
    }
}
