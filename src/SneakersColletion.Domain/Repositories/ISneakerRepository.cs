using SneakersColletion.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SneakersColletion.Domain.Repositories
{
    public interface ISneakerRepository
    {
        void CreateSneaker(Guid userId, Sneaker sneaker);
        void UpdateSneaker(Sneaker sneaker);
        void DeleteSneaker(int id);
        Sneaker GetSneakerById(int id);
        IEnumerable<Sneaker> GetAllSneakers();
        IEnumerable<Sneaker> SearchSneakers(string searchTerm);
    }
}
