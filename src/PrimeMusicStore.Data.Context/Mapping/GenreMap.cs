using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Data.Context.Mapping
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            // Primary Key
            builder.HasKey(t => t.GenreId);

            // Properties
            builder.Property(t => t.Name)
                .IsRequired();

            builder.Property(t => t.Description)
                .IsRequired(false);

            builder.Ignore(t => t.ValidationResult);

            var dataSeeder = new DataSeeder();
            builder.HasData(dataSeeder.Genres);
        }
    }
}