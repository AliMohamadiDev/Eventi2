using Eventi.Domain.EventCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class EventCategoryMapping : IEntityTypeConfiguration<EventCategory>
{
    public void Configure(EntityTypeBuilder<EventCategory> builder)
    {
        builder.ToTable("EventCategories");
        builder.HasKey(x => x.CategoryId);

        builder.Property(x => x.CategoryName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(360).IsRequired();

        builder.HasMany(x => x.EventSubcategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}