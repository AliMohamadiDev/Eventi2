namespace Eventi.Application.Contract.EventCategory;

public class EventCategoryViewModel
{
    public long CategoryId { get; set; }
    public string CategoryName { get;  set; }
    public string CreationDate { get; set; }
    public long EventSubcategoriesCount { get; set; }
}
