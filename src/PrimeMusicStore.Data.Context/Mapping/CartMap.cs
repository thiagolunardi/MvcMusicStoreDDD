using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Data.Context.Mapping
{
    public class CartMap : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            // Primary Key
            builder.HasKey(t => t.RecordId);

            // Properties
            builder.Property(t => t.CartId)
                .IsRequired();

            builder.Property(t => t.AlbumId)
                .IsRequired();

            builder.Property(t => t.Count)
                .IsRequired();

            builder.Property(t => t.DateCreated)
                .IsRequired();

            builder.Ignore(t => t.ValidationResult);
        }
    }
}