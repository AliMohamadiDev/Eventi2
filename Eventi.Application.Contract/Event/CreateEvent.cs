using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Eventi.Application.Contract.Event;

public class CreateEvent
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Name { get; set; }

    public IFormFile? ImageCover { get; set; }
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string ImageCoverTitle { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string ImageCoverAlt { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
    public long SubcategoryId { get; set; }

    public string? Tags { get; set; }
    
    [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
    public long PresenterId { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
    public long DepartmentId { get; set; }

    public bool IsWebinar { get; set; }
    public bool IsPrivate { get; set; }
    public bool PayByCustomer { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Slug { get; set; }
}