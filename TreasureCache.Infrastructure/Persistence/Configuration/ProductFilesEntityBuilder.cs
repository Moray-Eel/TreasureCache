using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreasureCache.Core.Entities;

namespace TreasureCache.Infrastructure.Persistence.Configuration;

public class ProductFilesEntityBuilder: IEntityTypeConfiguration<ProductFiles>
{
    public void Configure(EntityTypeBuilder<ProductFiles> productFiles)
    {
        productFiles.Property(b => b.Id).HasIdentityOptions(startValue: 100);
    }
}