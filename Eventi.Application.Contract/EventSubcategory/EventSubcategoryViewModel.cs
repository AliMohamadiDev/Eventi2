namespace Eventi.Application.Contract.EventSubcategory;

public class EventSubcategoryViewModel
{
    public long SubcategoryId { get; set; }
    public string SubcategoryName { get;  set; }
    public string Category { get; set; }
    public long CategoryId { get; set; }
    public string CreationDate { get; set; }
    public long EventsCount { get; set; }
}
