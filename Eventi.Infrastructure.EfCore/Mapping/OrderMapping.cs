using Eventi.Domain.OrderAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class OrderMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.IssueTrackingNo).HasMaxLength(8);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.AccountId);

        builder.HasOne(x => x.Ticket)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.TicketId);
    }
}