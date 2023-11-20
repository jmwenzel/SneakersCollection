using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SneakersColletion.Domain.Entities;
using SneakersColletion.Domain.Repositories;
using SneakersColletion.Domain.ValueObjects;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace SneakersCollection.Infrastructure.Authentication
{
    public class JwtAuthService : IAuthService
    {
        private readonly string _secretKey;
        private readonly IUserRepository _userRepository;

        public JwtAuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _secretKey = configuration["PrivateKey"];
            _userRepository = userRepository;
        }

        public string SignIn(string email, string password)
        {
            // Validate request
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new AuthenticationException("Invalid credentials");
            }

            // Authenticate user
            var user = _userRepository.GetUserByEmail(email);

            if (user == null || !user.ValidatePassword(password))
            {
                throw new AuthenticationException("Invalid credentials");
            }

            // Generate JWT token
            return GenerateJwtToken(email);
        }

        public void SignUp(string email, string password)
        {
            var newUser = new User(Guid.NewGuid(), new Email(email), new Password(password));
            _userRepository.AddUser(newUser);
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secretKey);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out _);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateJwtToken(string email)
        {
            var key = Encoding.ASCII.GetBytes(_secretKey); // Replace with a secure key
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
