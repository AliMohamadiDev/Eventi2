﻿using Eventi.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class RoleMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

        builder.OwnsMany(x => x.Permissions, navigationBuilder =>
        {
            navigationBuilder.HasKey(x => x.Id);
            navigationBuilder.ToTable("RolePermissions");
            navigationBuilder.Ignore(x => x.Name);
            navigationBuilder.WithOwner(x => x.Role);
        });
    }
}