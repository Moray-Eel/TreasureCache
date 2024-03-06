using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreasureCache.Core.Entities;

namespace TreasureCache.Infrastructure.Persistence.Configuration;

public class ProductEntityBuilder : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> product)
    {
        product.Property(c => c.BasePrice).HasColumnType("numeric(10, 2)");
        product.Property(b => b.Id).HasIdentityOptions(startValue: 100);
    }
}