using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class GenreMap : EntityTypeConfiguration<Genre>
    {
        public GenreMap()
        {
            // Primary Key
            HasKey(t => t.GenreId);

            // Properties
            Property(t => t.Name)
                .IsRequired();

            Property(t => t.Description)
                .IsOptional();

            Ignore(t => t.ValidationResult);
        }
    }
}