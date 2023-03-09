namespace Eventi.Application.Contract.EventCategory;

public class EditEventCategory
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Slug { get; set; }
}