using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreasureCache.Core.Entities;

namespace TreasureCache.Infrastructure.Persistence.Configuration;

public class AddressEntityBuilder : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> address)
    {
        address.Property(b => b.Id).HasIdentityOptions(startValue: 100);
    }
}