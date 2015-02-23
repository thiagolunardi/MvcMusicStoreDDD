using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class ArtistMap : EntityTypeConfiguration<Artist>
    {
        public ArtistMap()
        {
            // Primary Key
            HasKey(t => t.ArtistId);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            Ignore(t => t.ValidationResult);
        }
    }
}