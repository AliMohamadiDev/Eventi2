using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Eventi.Application.Contract.EventCategory;

namespace Eventi.Application.Contract.EventSubcategory;

public class CreateEventSubcategory
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string SubcategoryName { get; set; }

    [Range(1, 100000, ErrorMessage = ValidationMessage.IsRequired)]
    public long CategoryId { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Slug { get; set; }

    public List<EventCategoryViewModel> Categories { get; set; }
}