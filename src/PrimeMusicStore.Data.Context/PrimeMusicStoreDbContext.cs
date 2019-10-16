using Microsoft.EntityFrameworkCore;
using PrimeMusicStore.Data.Context.Mapping;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Data.Context
{
    public class PrimeMusicStoreDbContext : DbContext
    {
        public int? CurrentUserId { get; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums {get;set;}
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public PrimeMusicStoreDbContext(
            int? currentUserId = null)
            : base()
        {
            CurrentUserId = currentUserId;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new GenreMap())
                .ApplyConfiguration(new ArtistMap())
                .ApplyConfiguration(new AlbumMap())
                .ApplyConfiguration(new CartMap())
                .ApplyConfiguration(new OrderDetailMap())
                .ApplyConfiguration(new OrderMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("PrimeStore");
        }
    }
}