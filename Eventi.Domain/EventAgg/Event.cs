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

    public List<Ticket> Tickets { get; private set; } = new();

    public List<EventPresenters> EventPresenters { get; private set; } = new();

    public Department Department { get; private set; }
    public long DepartmentId { get; private set; }
    
    public string Slug { get; private set; }
    public bool IsRemoved { get; private set; }

    public string EventType { get; private set; }
    public string Address { get; private set; }
    public string SupportNumber { get; private set; }
    public string Description { get; private set; }
    public bool IsConfirmed { get; private set; }

    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }


    protected Event()
    {
    }

    public Event(string name, string imageCover, string imageCoverTitle, string imageCoverAlt, string? tags,
         string slug, long subcategoryId, long departmentId,string eventType,string address, string supportNumber, string description, DateTime startTime, DateTime endTime)
    {
        Name = name;
        ImageCover = imageCover;
        ImageCoverTitle = imageCoverTitle;
        ImageCoverAlt = imageCoverAlt;
        Tags = tags;
        Slug = slug;
        SubcategoryId = subcategoryId;
        CreationDate = DateTime.Now;
        DepartmentId = departmentId;
        EventType = eventType;
        Address = address;
        SupportNumber = supportNumber;
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
        IsRemoved = false;
        IsConfirmed = false;
    }

    public void Edit(string name, string imageCover, string imageCoverTitle, string imageCoverAlt, string? tags,
        string slug, long subcategoryId, long accountSideId, string eventType, string address, string supportNumber, string description, DateTime startTime, DateTime endTime)
    {
        Name = name;
        ImageCoverTitle = imageCoverTitle;
        ImageCoverAlt = imageCoverAlt;
        Tags = tags;
        Slug = slug;
        SubcategoryId = subcategoryId;
        DepartmentId = accountSideId;

        if (!string.IsNullOrWhiteSpace(imageCover))
            ImageCover = imageCover;

        EventType = eventType;
        Address = address;
        SupportNumber = supportNumber;
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
    }

    public void Remove()
    {
        IsRemoved = true;
    }

    public void Restore()
    {
        IsRemoved = false;
    }

    public void Confirm()
    {
        IsConfirmed = true;
    }

    public void Cancel()
    {
        IsConfirmed = false;
    }
}