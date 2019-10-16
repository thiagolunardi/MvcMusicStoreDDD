using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeMusicStore.Domain.Entities;

namespace PrimeMusicStore.Data.Context.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Primary Key
            builder.HasKey(t => t.OrderId);

            // Properties
            builder.Property(t => t.OrderDate)
                .IsRequired();

            builder.Property(t => t.Username)
                .IsRequired();

            builder.Property(t => t.FirstName)
                .HasMaxLength(160)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(160)
                .IsRequired();

            builder.Property(t => t.Address)
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(t => t.City)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(t => t.State)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(t => t.PostalCode)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(t => t.Country)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(t => t.Phone)
                .HasMaxLength(24)
                .IsRequired();

            builder.Property(t => t.Email)
                .IsRequired();


            builder.Ignore(t => t.ValidationResult);
        }

    }
}