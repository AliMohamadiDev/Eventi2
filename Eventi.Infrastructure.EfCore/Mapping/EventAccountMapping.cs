using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class EventAccountMapping : IEntityTypeConfiguration<EventAccount>
{
    public void Configure(EntityTypeBuilder<EventAccount> builder)
    {
        builder.ToTable("EventAccount");
        builder.HasKey(x => new {x.EventId, x.AccountId});

        builder.HasOne(x => x.Event)
            .WithMany(x => x.EventAccounts)
            .HasForeignKey(x => x.EventId);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.EventAccounts)
            .HasForeignKey(x => x.AccountId);
    }
}