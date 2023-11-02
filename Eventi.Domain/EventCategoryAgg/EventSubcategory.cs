using Eventi.Domain.EventAgg;

namespace Eventi.Domain.EventCategoryAgg;

public class EventSubcategory
{
    public long SubcategoryId { get; private set; }
    public string SubcategoryName { get; private set; }
    public string Slug { get; private set; }
    public DateTime CreationDate { get; private set; }
    public List<Event> Events { get; private set; } = new();

    protected EventSubcategory()
    {
    }

    public EventSubcategory(string subcategoryName, string slug)
    {
        SubcategoryName = subcategoryName;
        Slug = slug;
        CreationDate = DateTime.Now;
    }

    public void Edit(string subcategoryName, string slug)
    {
        SubcategoryName = subcategoryName;
        Slug = slug;
    }
}