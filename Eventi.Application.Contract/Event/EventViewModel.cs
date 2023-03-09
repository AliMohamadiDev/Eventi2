namespace Eventi.Application.Contract.Event;

public class EventViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ImageCover { get; set; }
    public long SubcategoryId { get; set; }
    public string Subcategory { get; set; }
    public long PresenterId { get; set; }
    public string Presenter { get; set; }
    public long AccountSideId { get; set; }
    public string AccountSide { get; set; }
    public bool IsWebinar { get; set; }
    public bool IsPrivate { get; set; }
    public bool PayByCustomer { get; set; }
    public string Link { get; set; }
}