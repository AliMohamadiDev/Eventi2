using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Eventi.Application.Contract.Role;
using Microsoft.AspNetCore.Http;

namespace Eventi.Application.Contract.Account;

public class RegisterAccount
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Firstname { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Lastname { get; set; }
    
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Password { get; set; }
    
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string? Email { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Mobile { get; set; }

    public IFormFile? ProfilePhoto { get; set; }

    public long RoleId { get; set; }

    public List<RoleViewModel> Roles { get; set; }
}