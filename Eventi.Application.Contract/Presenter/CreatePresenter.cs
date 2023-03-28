using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Eventi.Application.Contract.Presenter;

public class CreatePresenter
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public IFormFile? Logo { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string LogoTitle { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string LogoAlt { get; set; }

    public string Website { get; set; }
    public string Number { get; set; }
    public string Policy { get; set; }
    public string Description { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Slug { get; set; }
}