using SneakersCollection.API.App.DTOs;
using SneakersCollection.Infrastructure.Authentication;

namespace SneakersCollection.API.App.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IAuthService _authService;

        public AuthAppService(IAuthService authService)
        {
            _authService = authService;
        }

        public string SignIn(SignInRequest request)
        {
            return _authService.SignIn(request.Email, request.Password);
        }

        public void SignUp(SignUpRequest request)
        {
            _authService.SignUp(request.Email, request.Password);
        }
    }
}
