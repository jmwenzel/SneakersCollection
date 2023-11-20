using SneakersColletion.Domain.ValueObjects;
using System;

namespace SneakersColletion.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }

        public User() { } 

        public User(Guid id, Email email, Password password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public bool ValidatePassword(string password)
        {
            // Check password in a repo or external service
            return password.Equals("abc123!");
        }
    }
}
