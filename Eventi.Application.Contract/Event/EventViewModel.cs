namespace Eventi.Application.Contract.Event;

public class EventViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ImageCover { get; set; }
    public long SubcategoryId { get; set; }
    public string Subcategory { get; set; }
    public long PresenterId { get; set; }
    public string Presenter { get; set; }
    public long AccountSideId { get; set; }
    public string AccountSide { get; set; }

    public string EventType { get; set; }
    public string Address { get; set; }
    public string SupportNumber { get; set; }
    public string Description { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public bool IsConfirmed { get; set; }
    public List<long> PresenterIdList { get; set; } = new();
    public List<long> AccountIdList { get; set; } = new();
}