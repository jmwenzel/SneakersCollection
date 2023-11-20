namespace SneakersCollection.Infrastructure.Authentication
{
    public interface IAuthService
    {
        string SignIn(string email, string password);
        void SignUp(string email, string password);
        bool ValidateToken(string token);
    }
}
