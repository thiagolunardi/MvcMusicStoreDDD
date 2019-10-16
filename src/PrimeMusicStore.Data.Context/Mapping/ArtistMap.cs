using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Data.Context.Mapping
{
    public class ArtistMap : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ArtistId);

            // Properties
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Ignore(t => t.ValidationResult);

            var dataSeeder = new DataSeeder();
            builder.HasData(dataSeeder.Artists);
        }
    }
}
