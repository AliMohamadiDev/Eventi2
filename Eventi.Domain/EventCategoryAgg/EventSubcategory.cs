using Eventi.Domain.EventAgg;

namespace Eventi.Domain.EventCategoryAgg;

public class EventSubcategory
{
    public long SubcategoryId { get; private set; }
    public string SubcategoryName { get; private set; }
    public string Slug { get; private set; }
    public long CategoryId { get; private set; }
    public EventCategory Category { get; private set; }
    public DateTime CreationDate { get; private set; }
    public List<Event> Events { get; private set; } = new();

    protected EventSubcategory()
    {
    }

    public EventSubcategory(string subcategoryName, long categoryId, string slug)
    {
        SubcategoryName = subcategoryName;
        CategoryId = categoryId;
        Slug = slug;
        CreationDate = DateTime.Now;
    }

    public void Edit(string subcategoryName, long categoryId, string slug)
    {
        SubcategoryName = subcategoryName;
        CategoryId = categoryId;
        Slug = slug;
    }
}