using System;

namespace SneakersColletion.Domain.Entities
{
    public class Sneaker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public double SizeUS { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }

        public Sneaker()
        {

        }

        public Sneaker(Guid id, string name, string brand, double price, double sizeUS, int year, double rate)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Price = price;
            SizeUS = sizeUS;
            Year = year;
            Rate = rate;
        }
    }
}
