using Eventi.Domain.EventCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class EventSubcategoryMapping : IEntityTypeConfiguration<EventSubcategory>
{
    public void Configure(EntityTypeBuilder<EventSubcategory> builder)
    {
        builder.ToTable("EventSubcategories");
        builder.HasKey(x => x.SubcategoryId);

        builder.Property(x => x.SubcategoryName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(360).IsRequired();

        builder.HasMany(x => x.Events)
            .WithOne(x => x.Subcategory)
            .HasForeignKey(x => x.SubcategoryId);
    }
}