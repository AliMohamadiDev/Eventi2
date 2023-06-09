using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class EventMapping : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(256).IsRequired();
        builder.Property(e => e.ImageCover).HasMaxLength(2048).IsRequired();
        builder.Property(e => e.ImageCoverAlt).HasMaxLength(512).IsRequired();
        builder.Property(e => e.ImageCoverTitle).HasMaxLength(512).IsRequired();
        builder.Property(e => e.Tags).HasMaxLength(2024);
        builder.Property(e => e.Slug).HasMaxLength(360).IsRequired();
        builder.Property(e => e.EventType).HasMaxLength(64).IsRequired();
        builder.Property(e => e.Address).HasMaxLength(1024).IsRequired();
        builder.Property(e => e.SupportNumber).HasMaxLength(16).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(4096).IsRequired();

        builder.HasOne(x => x.Subcategory)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.SubcategoryId);

        /*builder.HasOne(x => x.Presenter)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.PresenterId);*/

        builder.HasMany(x => x.Tickets)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId);

        /*builder.HasOne(x => x.Department)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.DepartmentId);*/

        /*builder.HasOne(e => e.Department)
            .WithOne(e => e.Event)
            .HasForeignKey<Department>(x => x.EventId);*/

        //builder.HasMany(x=>x.)
    }
}