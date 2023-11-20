using Moq;
using SneakersCollection.API.App.DTOs;
using SneakersCollection.API.App.Services;
using SneakersCollection.Infrastructure.Authentication;
using Xunit;

namespace SneakersCollection.Test.App.Services
{
    public class AuthAppServiceTests
    {
        [Fact]
        public void SignIn_CallsAuthServiceSignIn()
        {
            // Arrange
            var mockAuthService = new Mock<IAuthService>();
            var authAppService = new AuthAppService(mockAuthService.Object);

            var signInRequest = new SignInRequest { Email = "test@example.com", Password = "password123" };

            // Act
            authAppService.SignIn(signInRequest);

            // Assert
            mockAuthService.Verify(x => x.SignIn(signInRequest.Email, signInRequest.Password), Times.Once);
        }

        [Fact]
        public void SignUp_CallsAuthServiceSignUp()
        {
            // Arrange
            var mockAuthService = new Mock<IAuthService>();
            var authAppService = new AuthAppService(mockAuthService.Object);

            var signUpRequest = new SignUpRequest { Email = "test@example.com", Password = "password123" };

            // Act
            authAppService.SignUp(signUpRequest);

            // Assert
            mockAuthService.Verify(x => x.SignUp(signUpRequest.Email, signUpRequest.Password), Times.Once);
        }

    }
}
