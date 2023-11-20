using SneakersColletion.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SneakersColletion.Domain.AggregateRoot
{
    public class SneakerCollection
    {
        public Guid UserId { get; set; }
        public List<Sneaker> Sneakers = new List<Sneaker>();

        public void AddSneaker(Sneaker sneaker)
        {
            Sneakers.Add(sneaker);
        }

    }
}
