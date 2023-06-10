using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Eventi.Application.Contract.Slide;

public class CreateSlide
{
    public IFormFile Picture { get;  set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string PictureAlt { get;  set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string PictureTitle { get;  set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Link { get; set; }
}