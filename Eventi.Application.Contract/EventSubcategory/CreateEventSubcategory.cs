using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace Eventi.Application.Contract.EventSubcategory;

public class CreateEventSubcategory
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string SubcategoryName { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Slug { get; set; }
}