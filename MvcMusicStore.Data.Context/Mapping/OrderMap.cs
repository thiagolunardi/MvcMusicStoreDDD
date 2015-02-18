using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            HasKey(t => t.OrderId);

            // Properties
            Property(t => t.OrderDate)
                .IsRequired();

            Property(t => t.Username)
                .IsRequired();

            Property(t => t.FirstName)
                .HasMaxLength(160)
                .IsRequired();

            Property(t => t.LastName)
                .HasMaxLength(160)
                .IsRequired();

            Property(t => t.Address)
                .HasMaxLength(70)
                .IsRequired();

            Property(t => t.City)
                .HasMaxLength(40)
                .IsRequired();

            Property(t => t.State)
                .HasMaxLength(40)
                .IsRequired();

            Property(t => t.PostalCode)
                .HasMaxLength(10)
                .IsRequired();

            Property(t => t.Country)
                .HasMaxLength(40)
                .IsRequired();

            Property(t => t.Phone)
                .HasMaxLength(24)
                .IsRequired();

            Property(t => t.Email)
                .IsRequired();


            Ignore(t => t.ValidationResult);
        }
    }
}