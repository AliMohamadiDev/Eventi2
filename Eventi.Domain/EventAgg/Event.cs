using Eventi.Domain.EventCategoryAgg;

namespace Eventi.Domain.EventAgg;

public class Event
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string ImageCover { get; private set; }
    public string ImageCoverTitle { get; private set; }
    public string ImageCoverAlt { get; private set; }

    public long SubcategoryId { get; private set; }
    public EventSubcategory Subcategory { get; private set; }

    public string? Tags { get; private set; }
    public DateTime CreationDate { get; private set; }

    public EventInfo EventInfo { get; private set; }

    public List<Ticket> Tickets { get; private set; } = new();

    public List<EventPresenters> EventPresenters { get; private set; } = new();

    public Department Department { get; private set; }
    public long DepartmentId { get; private set; }

    public bool IsWebinar { get; private set; }
    public bool IsPrivate { get; private set; }
    public bool PayByCustomer { get; private set; }
    public string Link { get; private set; }
    public string Slug { get; private set; }

    protected Event()
    {
    }

    public Event(string name, string imageCover, string imageCoverTitle, string imageCoverAlt, string? tags,
        bool isWebinar, bool isPrivate, bool payByCustomer, string link, string slug, long subcategoryId, long departmentId)
    {
        Name = name;
        ImageCover = imageCover;
        ImageCoverTitle = imageCoverTitle;
        ImageCoverAlt = imageCoverAlt;
        Tags = tags;
        IsWebinar = isWebinar;
        IsPrivate = isPrivate;
        PayByCustomer = payByCustomer;
        Link = link;
        Slug = slug;
        SubcategoryId = subcategoryId;
        CreationDate = DateTime.Now;
        DepartmentId = departmentId;
    }

    public void Edit(string name, string imageCover, string imageCoverTitle, string imageCoverAlt, string? tags,
        bool isWebinar, bool isPrivate, bool payByCustomer, string link, string slug, long subcategoryId, long accountSideId)
    {
        Name = name;
        ImageCover = imageCover;
        ImageCoverTitle = imageCoverTitle;
        ImageCoverAlt = imageCoverAlt;
        Tags = tags;
        IsWebinar = isWebinar;
        IsPrivate = isPrivate;
        PayByCustomer = payByCustomer;
        Link = link;
        Slug = slug;
        SubcategoryId = subcategoryId;
        DepartmentId = accountSideId;
    }
}