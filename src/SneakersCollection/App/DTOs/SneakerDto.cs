using System;

namespace SneakersCollection.API.App.DTOs
{
    public class SneakerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public double SizeUS { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }

    }
}
