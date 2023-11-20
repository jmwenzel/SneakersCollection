using SneakersCollection.API.App.DTOs;

namespace SneakersCollection.API.App.Services
{
    public interface IAuthAppService
    {
        string SignIn(SignInRequest request);
        void SignUp(SignUpRequest request);
    }
}
