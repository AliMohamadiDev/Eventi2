namespace Eventi.Domain.EventCategoryAgg;

public class EventCategory
{
    public long CategoryId { get; private set; }
    public string CategoryName { get; private set; }
    public string Slug { get; private set; }
    public DateTime CreationDate { get; private set; }
    public List<EventSubcategory> EventSubcategories { get; private set; } = new();

    protected EventCategory()
    {
    }

    public EventCategory(string categoryName, string slug)
    {
        CategoryName = categoryName;
        Slug = slug;
        CreationDate = DateTime.Now;
    }

    public void Edit(string categoryName, string slug)
    {
        CategoryName = categoryName;
        Slug = slug;
    }
}