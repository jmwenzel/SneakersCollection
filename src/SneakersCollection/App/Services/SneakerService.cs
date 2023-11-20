using SneakersCollection.API.App.DTOs;
using SneakersColletion.Domain.Entities;
using SneakersColletion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakersCollection.API.App.Services
{
    public class SneakerService : ISneakerService
    {
        private readonly ISneakerRepository _sneakerRepository;
        private readonly IUserRepository _userRepository;

        public SneakerService(ISneakerRepository sneakerRepository, IUserRepository userRepository)
        {
            _sneakerRepository = sneakerRepository;
            _userRepository = userRepository;
        }

        public void CreateSneaker(Guid userId, SneakerDto sneakerDto)
        {
            // Validate user existence (you might want to implement this method in UserRepository)
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                // Handle user not found, for example, by throwing an exception
                throw new KeyNotFoundException("User not found");
            }

            // Create a Sneaker entity based on the DTO
            var sneaker = new Sneaker
            {
                Name = sneakerDto.Name,
                Brand = sneakerDto.Brand,
                Price = sneakerDto.Price,
                Rate = sneakerDto.Rate,
                SizeUS = sneakerDto.SizeUS,
                Year = sneakerDto.Year
            };

            // Save changes to the repository
            _sneakerRepository.CreateSneaker(userId, sneaker);
        }

        public IEnumerable<Sneaker> GetAllSneakers(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sneaker> SearchSneakers(Guid userId, string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void UpdateSneaker(Guid userId, SneakerDto sneaker)
        {
            throw new NotImplementedException();
        }
    }
}
