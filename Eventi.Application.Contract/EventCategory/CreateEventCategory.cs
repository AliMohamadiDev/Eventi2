using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace Eventi.Application.Contract.EventCategory;

public class CreateEventCategory
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string CategoryName { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Slug { get; set; }
}