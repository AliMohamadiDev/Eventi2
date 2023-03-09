using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class DepartmentAccountMapping : IEntityTypeConfiguration<DepartmentAccount>
{
    public void Configure(EntityTypeBuilder<DepartmentAccount> builder)
    {
        builder.ToTable("DepartmentAccounts");
        builder.HasKey(x => new {x.DepartmentId, x.AccountId});

        /*builder.HasOne(x=>x.DepartmentId)
            .WithMany(x=>x.)*/
    }
}