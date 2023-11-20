using SneakersColletion.Domain.Entities;
using System;

namespace SneakersColletion.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        User GetUserById(Guid id);
        void AddUser(User user);
    }
}
