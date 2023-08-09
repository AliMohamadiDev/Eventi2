using Eventi.Domain.EventAgg;

namespace _01_EventiQuery.Contracts.Event;

public class EventQueryModel
{
    public long Id { get; set; }
    public string Name { get; set; }

    public string ImageCover { get; set; }
    public string ImageCoverTitle { get; set; }
    public string ImageCoverAlt { get; set; }

    public long SubcategoryId { get; set; }
    public string Subcategory { get; set; }
    public string SubcategorySlug { get; set; }

    public long PresenterId { get; set; }
    public Eventi.Domain.EventAgg.Presenter Presenter { get; set; }
    public string? DepartmentName { get; set; }
    public string? DepartmentSlug { get; set; }
    //public bool IsWebinar { get; set; }
    public string Slug { get; set; }
    public List<string> Tags { get; set; } = new();
    public List<TicketQueryModel> Tickets { get; set; } = new();

    public string EventType { get; set; }
    public string Address { get; set; }
    public string SupportNumber { get; set; }
    public string Description { get; set; }
    public bool IsConfirmed { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}