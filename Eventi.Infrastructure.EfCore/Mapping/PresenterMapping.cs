using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class PresenterMapping : IEntityTypeConfiguration<Presenter>
{
    public void Configure(EntityTypeBuilder<Presenter> builder)
    {
        builder.ToTable("Presenters");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
        builder.Property(x => x.Logo).HasMaxLength(2048).IsRequired();
        builder.Property(x => x.LogoAlt).HasMaxLength(512).IsRequired();
        builder.Property(x => x.LogoTitle).HasMaxLength(512).IsRequired();
        builder.Property(x => x.Website).HasMaxLength(256);
        builder.Property(x => x.Number).HasMaxLength(32);
        builder.Property(x => x.Policy).HasMaxLength(2048);
        builder.Property(x => x.Description).HasMaxLength(2048);
        builder.Property(x => x.Slug).HasMaxLength(360).IsRequired();

        /*builder.HasMany(x=>x.Events)
            .WithOne(x=>x.Presenter)
            .HasForeignKey(x=>x.PresenterId);*/
    }
}