using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class TicketMapping : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).HasMaxLength(256).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(20000);

        builder.HasOne(x => x.Event)
            .WithMany(x => x.Tickets)
            .HasForeignKey(x => x.EventId);

        builder.HasMany(x => x.DiscountCodes)
            .WithOne(x => x.Ticket)
            .HasForeignKey(x => x.TicketId);

        builder.HasMany(x => x.Orders)
            .WithOne(x => x.Ticket)
            .HasForeignKey(x => x.TicketId);
    }
}