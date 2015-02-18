using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            // Primary Key
            HasKey(t => t.RecordId);

            // Properties
            Property(t => t.CartId)
                .IsRequired();

            Property(t => t.AlbumId)
                .IsRequired();

            Property(t => t.Count)
                .IsRequired();

            Property(t => t.DateCreated)
                .IsRequired();

            Ignore(t => t.ValidationResult);
        }
    }
}