using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Eventi.Application.Contract.Department;

public class CreateDepartment
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Name { get; set; }

    //[StringLength(10, MinimumLength = 10, ErrorMessage = ValidationMessage.FixedLength10)]
    public long NationalCode { get; set; }

    //[StringLength(10, MinimumLength = 10, ErrorMessage = ValidationMessage.FixedLength10)]
    public long PostalCode { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Address { get; set; }

    //[Required(ErrorMessage = ValidationMessage.IsRequired)]
    public IFormFile? Logo { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string LogoTitle { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string LogoAlt { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Slug { get; set; }
}