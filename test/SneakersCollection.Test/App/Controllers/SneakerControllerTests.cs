using Microsoft.AspNetCore.Mvc;
using Moq;
using SneakersCollection.API.App.Controllers;
using SneakersCollection.API.App.DTOs;
using SneakersCollection.API.App.Services;
using SneakersColletion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SneakersCollection.Test.App.Controllers
{
    public class SneakerControllerTests
    {
        [Fact]
        public void CreateSneaker_Success_ReturnsOkWithMessage()
        {
            // Arrange
            var mockSneakerService = new Mock<ISneakerService>();
            mockSneakerService.Setup(x => x.CreateSneaker(It.IsAny<Guid>(), It.IsAny<SneakerDto>()));
            var controller = new SneakerController(mockSneakerService.Object);

            // Act
            var userId = Guid.NewGuid();
            var sneakerDto = new SneakerDto { Name = "Air Jordan", Brand = "Nike" };
            var result = controller.CreateSneaker(userId, sneakerDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("{ Message = Sneaker created successfully }", result.Value.ToString());
        }

        [Fact]
        public void ListSneakers_Success_ReturnsOkWithSneakers()
        {
            // Arrange
            var mockSneakerService = new Mock<ISneakerService>();
            mockSneakerService.Setup(x => x.GetAllSneakers(It.IsAny<Guid>())).Returns(new List<Sneaker>());
            var controller = new SneakerController(mockSneakerService.Object);

            // Act
            var userId = Guid.NewGuid();
            var result = controller.ListSneakers(userId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            // You might want to assert the content of the result, e.g., the list of sneakers
        }

        [Fact]
        public void SearchSneakers_Success_ReturnsOkWithSneakers()
        {
            // Arrange
            var mockSneakerService = new Mock<ISneakerService>();
            mockSneakerService.Setup(x => x.SearchSneakers(It.IsAny<Guid>(), It.IsAny<string>())).Returns(new List<Sneaker>());
            var controller = new SneakerController(mockSneakerService.Object);

            // Act
            var userId = Guid.NewGuid();
            var searchTerm = "someSearchTerm";
            var result = controller.SearchSneakers(userId, searchTerm) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateSneaker_Success_ReturnsOkWithMessage()
        {
            // Arrange
            var mockSneakerService = new Mock<ISneakerService>();
            mockSneakerService.Setup(x => x.UpdateSneaker(It.IsAny<Guid>(), It.IsAny<SneakerDto>()));
            var controller = new SneakerController(mockSneakerService.Object);

            // Act
            var userId = Guid.NewGuid();
            var sneakerDto = new SneakerDto { /* Set properties as needed */ };
            var result = controller.UpdateSneaker(userId, sneakerDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("{ Message = Sneaker updated successfully }", result.Value.ToString());
        }
    }
}
