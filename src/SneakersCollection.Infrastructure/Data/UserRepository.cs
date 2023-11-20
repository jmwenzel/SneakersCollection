using SneakersColletion.Domain.Entities;
using SneakersColletion.Domain.Repositories;
using System;

namespace SneakersCollection.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByEmail(string email)
        {
            // Implementation of data access logic using Entity Framework Core
            return new User();
        }

        public void AddUser(User user)
        {
            // Implementation of data access logic using Entity Framework Core
        }

        public User GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
