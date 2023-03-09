using _01_EventiQuery.Contracts.Event;

namespace _01_EventiQuery.Contracts.EventCategory;

public class EventSubcategoryQueryModel
{
    public long SubcategoryId { get; set; }
    public string SubcategoryName { get; set; }
    public string Category { get; set; }
    public long CategoryId { get; set; }
    public string Slug { get; set; }
    public List<EventQueryModel> Events { get; set; } = new();
}