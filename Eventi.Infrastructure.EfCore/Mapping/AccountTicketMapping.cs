using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class AccountTicketMapping : IEntityTypeConfiguration<AccountTicket>
{
    public void Configure(EntityTypeBuilder<AccountTicket> builder)
    {
        builder.ToTable("AccountTicket");
        builder.HasKey(x => new {x.EventId, x.TicketId, x.AccountId});

        builder.HasOne(x => x.Account)
            .WithMany(x => x.AccountTickets)
            .HasForeignKey(x => x.AccountId);

        builder.HasOne(x => x.Ticket)
            .WithMany(x => x.AccountTickets)
            .HasForeignKey(x => x.TicketId);
    }
}