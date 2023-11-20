using Moq;
using SneakersCollection.API.App.DTOs;
using SneakersCollection.API.App.Services;
using SneakersColletion.Domain.Entities;
using SneakersColletion.Domain.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace SneakersCollection.Test.App.Services
{
    public class SneakerServiceTests
    {
        [Fact]
        public void CreateSneaker_ValidUser_CallsRepositories()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var sneakerDto = new SneakerDto { };

            var mockSneakerRepository = new Mock<ISneakerRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(x => x.GetUserById(userId)).Returns(new User { });

            var sneakerService = new SneakerService(mockSneakerRepository.Object, mockUserRepository.Object);

            // Act
            sneakerService.CreateSneaker(userId, sneakerDto);

            // Assert
            mockUserRepository.Verify(x => x.GetUserById(userId), Times.Once);
            mockSneakerRepository.Verify(x => x.CreateSneaker(userId, It.IsAny<Sneaker>()), Times.Once);
        }

        [Fact]
        public void CreateSneaker_InvalidUser_ThrowsKeyNotFoundException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var sneakerDto = new SneakerDto {  };

            var mockSneakerRepository = new Mock<ISneakerRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(x => x.GetUserById(userId)).Returns((User)null);

            var sneakerService = new SneakerService(mockSneakerRepository.Object, mockUserRepository.Object);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => sneakerService.CreateSneaker(userId, sneakerDto));
        }

    }
}
