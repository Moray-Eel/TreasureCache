using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreasureCache.Core.Entities;

namespace TreasureCache.Infrastructure.Persistence.Configuration;

public class CurrencyEntityBuilder : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> currency)
    {
        currency.Property(c => c.Rate).HasColumnType("numeric(10, 2)"); 
        currency.Property(b => b.Id).HasIdentityOptions(startValue: 10);
    }
}