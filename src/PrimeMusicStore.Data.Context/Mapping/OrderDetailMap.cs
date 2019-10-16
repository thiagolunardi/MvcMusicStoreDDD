using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Data.Context.Mapping
{
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            // Primary Key
            builder.HasKey(t => t.OrderDetailId);

            // Properties
            builder.Property(t => t.Quantity)
                .IsRequired();

            // Relationship
            builder.HasOne(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.OrderId);

            builder.HasOne(t => t.Album)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.AlbumId);

            builder.Ignore(t => t.ValidationResult);
        }
    }
}