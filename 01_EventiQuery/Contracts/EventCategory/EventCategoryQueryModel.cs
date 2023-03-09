namespace _01_EventiQuery.Contracts.EventCategory;

public class EventCategoryQueryModel
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CreationDate { get; set; }
    public string Slug { get; set; }
    public List<EventSubcategoryQueryModel> EventSubcategories { get; set; } = new();
}