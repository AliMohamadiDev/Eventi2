using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class DepartmentAccountMapping : IEntityTypeConfiguration<DepartmentAccount>
{
    public void Configure(EntityTypeBuilder<DepartmentAccount> builder)
    {
        builder.ToTable("DepartmentAccounts");
        builder.HasKey(x => new {x.DepartmentId, x.AccountId});

        builder.HasOne(x => x.Department)
            .WithMany(x => x.DepartmentAccounts)
            .HasForeignKey(x => x.DepartmentId);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.DepartmentAccounts)
            .HasForeignKey(x => x.AccountId);
    }
}