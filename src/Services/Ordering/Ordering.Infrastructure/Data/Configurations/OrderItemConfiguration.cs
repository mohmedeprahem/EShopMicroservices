using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);
        builder.Property(oi => oi.Id)
            .HasConversion(
                id => id.Value,
                value => OrderItemId.Of(value)
            );

        builder.Property(oi => oi.Quantity)
            .IsRequired();

        builder.Property(oi => oi.Price).IsRequired();

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);
    }
}
