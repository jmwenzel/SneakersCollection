using Microsoft.EntityFrameworkCore;
using SneakersColletion.Domain.Entities;
using SneakersColletion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SneakersCollection.Infrastructure.Data
{
    public class SneakerRepository : ISneakerRepository
    {
        private readonly MyDbContext _dbContext;

        public SneakerRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateSneaker(Guid userId, Sneaker sneaker)
        {
            var userCollection = _dbContext.SneakerCollections
                .Include(sc => sc.Sneakers)
                .FirstOrDefault(sc => sc.UserId == userId);

            if (userCollection != null)
            {
                userCollection.AddSneaker(sneaker);
                _dbContext.SaveChanges();
            }
            else
            {
                // Handle scenario where user collection doesn't exist
                
            }
        }

        public void UpdateSneaker(Sneaker sneaker)
        {
            // Update the sneaker in the database
            _dbContext.SaveChanges();
        }

        public void DeleteSneaker(int id)
        {
            var sneakerToRemove = _dbContext.Sneakers.Find(id);
            if (sneakerToRemove != null)
            {
                _dbContext.Sneakers.Remove(sneakerToRemove);
                _dbContext.SaveChanges();
            }
            else
            {
                // Handle scenario where sneaker doesn't exist
                
            }
        }

        public Sneaker GetSneakerById(int id)
        {
            return _dbContext.Sneakers.Find(id);
        }

        public IEnumerable<Sneaker> GetAllSneakers()
        {
            return _dbContext.Sneakers.ToList();
        }

        public IEnumerable<Sneaker> SearchSneakers(string searchTerm)
        {
            // For simplicity, searching by name or brand
            return _dbContext.Sneakers
                .Where(s => s.Name.Contains(searchTerm) || s.Brand.Contains(searchTerm))
                .ToList();
        }
    }
}
