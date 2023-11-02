using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreasureCache.Core.Entities;

namespace TreasureCache.Infrastructure.Persistence.Configuration;

public class CategoryEntityBuilder : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> category)
    {
        category.HasOne(e => e.ParentCategory)
            .WithMany(e => e.SubCategories)
            .HasForeignKey(e => e.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        category.Property(b => b.Id).HasIdentityOptions(startValue: 100);
    }
}