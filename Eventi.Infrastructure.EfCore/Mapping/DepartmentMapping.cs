using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class DepartmentMapping : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
        builder.Property(x => x.Address).HasMaxLength(2048).IsRequired();
        builder.Property(x => x.Logo).HasMaxLength(2048).IsRequired();
        builder.Property(x => x.LogoAlt).HasMaxLength(512).IsRequired();
        builder.Property(x => x.LogoTitle).HasMaxLength(512).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(360).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(20000);

        builder.HasMany(x => x.Events)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId);
    }
}