using Microsoft.AspNetCore.Http;

namespace Eventi.Application.Contract.Event;

public class CreateEvent
{
    public string Name { get; set; }
    public IFormFile? ImageCover { get; set; }
    public string ImageCoverTitle { get; set; }
    public string ImageCoverAlt { get; set; }
    public long SubcategoryId { get; set; }
    public string? Tags { get; set; }
    public long PresenterId { get; set; }
    public long DepartmentId { get; set; }
    public bool IsWebinar { get; set; }
    public bool IsPrivate { get; set; }
    public bool PayByCustomer { get; set; }
    public string Link { get; set; }
    public string Slug { get; set; }
}