using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace Eventi.Application.Contract.Account;

public class Login
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Mobile { get; set; }

    public string Email { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Password { get; set; }
}