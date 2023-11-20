using Microsoft.AspNetCore.Mvc;
using Moq;
using SneakersCollection.API.App.Controllers;
using SneakersCollection.API.App.DTOs;
using SneakersCollection.API.App.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using Xunit;

namespace SneakersCollection.Test.App.Controllers
{
    public class AuthControllerTests
    {
        [Fact]
        public void SignIn_Success_ReturnsOkWithToken()
        {
            // Arrange
            var mockAuthAppService = new Mock<IAuthAppService>();
            mockAuthAppService.Setup(x => x.SignIn(It.IsAny<SignInRequest>())).Returns("fakeToken");

            var controller = new AuthController(mockAuthAppService.Object);

            // Act
            var signInRequest = new SignInRequest { Email = "sample@mail.com", Password = "abc123!" };
            var result = controller.SignIn(signInRequest) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("{ Token = fakeToken }", result.Value.ToString());
        }

        [Fact]
        public void SignIn_AuthenticationException_ReturnsUnauthorized()
        {
            // Arrange
            var mockAuthAppService = new Mock<IAuthAppService>();
            mockAuthAppService.Setup(x => x.SignIn(It.IsAny<SignInRequest>())).Throws(new AuthenticationException("Invalid credentials"));

            var controller = new AuthController(mockAuthAppService.Object);

            // Act
            var signInRequest = new SignInRequest { Email = "sample@mail.com", Password = "not_my_password" };
            var result = controller.SignIn(signInRequest) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("Invalid credentials", result.Value.ToString());
        }

        [Fact]
        public void SignUp_Success_ReturnsOkWithMessage()
        {
            // Arrange
            var mockAuthAppService = new Mock<IAuthAppService>();
            var controller = new AuthController(mockAuthAppService.Object);

            // Act
            var signUpRequest = new SignUpRequest { Email = "sample@mail.com", Password = "abc123!" };
            var result = controller.SignUp(signUpRequest) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("{ Message = Account created successfully }", result.Value.ToString());
        }

        [Fact]
        public void SignUp_ValidationException_ReturnsBadRequest()
        {
            // Arrange
            var mockAuthAppService = new Mock<IAuthAppService>();
            mockAuthAppService.Setup(x => x.SignUp(It.IsAny<SignUpRequest>())).Throws(new ValidationException("Validation failed"));

            var controller = new AuthController(mockAuthAppService.Object);

            // Act
            var signUpRequest = new SignUpRequest { Email = "invalid@mail.com", Password = "XXXXXXX" };
            var result = controller.SignUp(signUpRequest) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Validation failed", result.Value.ToString());
        }
    }
}
