using Microsoft.Extensions.Configuration;
using Moq;
using SneakersCollection.Infrastructure.Authentication;
using SneakersColletion.Domain.Entities;
using SneakersColletion.Domain.Repositories;
using System.Security.Authentication;
using Xunit;

namespace SneakersCollection.Test.Infrastructure.Authentication
{
    public class JwtAuthServiceTests
    {
        [Fact]
        public void SignIn_InvalidCredentials_ThrowsAuthenticationException()
        {
            // Arrange
            var email = "test@example.com";
            var password = "invalidPassword";

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetUserByEmail(email)).Returns((User)null);

            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["PrivateKey"]).Returns("yourTestPrivateKey");
            var jwtAuthService = new JwtAuthService(mockUserRepository.Object, mockConfiguration.Object);

            // Act & Assert
            Assert.Throws<AuthenticationException>(() => jwtAuthService.SignIn(email, password));
        }

        [Fact]
        public void SignUp_ValidCredentials_AddsUser()
        {
            // Arrange
            var email = "test@example.com";
            var password = "password123";

            var mockUserRepository = new Mock<IUserRepository>();

            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["PrivateKey"]).Returns("yourTestPrivateKey");
            var jwtAuthService = new JwtAuthService(mockUserRepository.Object, mockConfiguration.Object);

            // Act
            jwtAuthService.SignUp(email, password);

            // Assert
            mockUserRepository.Verify(x => x.AddUser(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void ValidateToken_InvalidToken_ReturnsFalse()
        {
            // Arrange
            var invalidToken = "invalidToken";

            var mockUserRepository = new Mock<IUserRepository>();

            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["PrivateKey"]).Returns("yourTestPrivateKey");
            var jwtAuthService = new JwtAuthService(mockUserRepository.Object, mockConfiguration.Object);

            // Act
            var isValid = jwtAuthService.ValidateToken(invalidToken);

            // Assert
            Assert.False(isValid);
        }
    }
}
