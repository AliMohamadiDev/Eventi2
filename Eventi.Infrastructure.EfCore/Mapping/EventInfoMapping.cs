using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class EventInfoMapping : IEntityTypeConfiguration<EventInfo>
{
    public void Configure(EntityTypeBuilder<EventInfo> builder)
    {
        builder.ToTable("EventInfos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.State).HasMaxLength(256);
        builder.Property(x => x.City).HasMaxLength(256);
        builder.Property(x => x.Address).HasMaxLength(4096);
        builder.Property(x => x.HostingService).HasMaxLength(256);
        builder.Property(x => x.LoginLink).HasMaxLength(256);
        builder.Property(x => x.Description).HasMaxLength(20000);
    }
}