using Microsoft.EntityFrameworkCore;
using SneakersColletion.Domain.AggregateRoot;
using SneakersColletion.Domain.Entities;

namespace SneakersCollection.Infrastructure
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Sneaker> Sneakers { get; set; }
        public virtual DbSet<SneakerCollection> SneakerCollections { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
       
    }
}
