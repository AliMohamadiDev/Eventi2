namespace Eventi.Application.Contract.Event;

public class EventSearchModel
{
    public string? Name { get; set; }
    public long SubcategoryId { get; set; }
    public long AccountSideId { get; set; }
    public long PresenterId { get; set; }
    public bool IsWebinar { get; set; }
    public bool IsPrivate { get; set; }
}