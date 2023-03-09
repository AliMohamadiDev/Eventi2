using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventi.Infrastructure.EfCore.Mapping;

public class EventPresentersMapping : IEntityTypeConfiguration<EventPresenters>
{
    public void Configure(EntityTypeBuilder<EventPresenters> builder)
    {
        builder.ToTable("EventPresenters");
        builder.HasKey(x => new {x.EventId, x.PresenterId});

        builder.HasOne(x => x.Event)
            .WithMany(x => x.EventPresenters)
            .HasForeignKey(x => x.EventId);

        builder.HasOne(x => x.Presenter)
            .WithMany(x => x.EventPresenters)
            .HasForeignKey(x => x.PresenterId);
    }
}