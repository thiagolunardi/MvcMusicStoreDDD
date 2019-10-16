using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Data.Context.Mapping
{
    public class AlbumMap : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            // Primary Key
            builder.HasKey(t => t.AlbumId);

            // Properties
            builder.Property(t => t.Title)
                .HasMaxLength(160)
                .IsRequired();

            builder.Property(t => t.Price)
                .IsRequired();

            // Relationship
            builder.HasOne(t => t.Artist)
                .WithMany(t => t.Albums)
                .HasForeignKey(t => t.ArtistId);

            builder.HasOne(t => t.Genre)
                .WithMany(t => t.Albums)
                .HasForeignKey(t => t.GenreId);

            builder.Ignore(t => t.ValidationResult);

            var dataSeeder = new DataSeeder();
            builder.HasData(dataSeeder.Albums);
        }
    }
}
