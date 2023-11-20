using SneakersCollection.API.App.DTOs;
using SneakersColletion.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SneakersCollection.API.App.Services
{
    public interface ISneakerService
    {
        void CreateSneaker(Guid userId, SneakerDto sneakerDto);
        void UpdateSneaker(Guid userId, SneakerDto sneaker);
        IEnumerable<Sneaker> GetAllSneakers(Guid userId);
        IEnumerable<Sneaker> SearchSneakers(Guid userId, string searchTerm);
    }
}
