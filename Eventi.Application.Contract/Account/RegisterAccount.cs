using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Eventi.Application.Contract.Role;
using Microsoft.AspNetCore.Http;

namespace Eventi.Application.Contract.Account;

public class RegisterAccount
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Fullname { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Password { get; set; }
    
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string? Email { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Mobile { get; set; }

    public string? State { get; set; }
    public string? City { get; set; }
    public string? Birthday { get; set; }

    public string NationalCode { get; set; }

    public IFormFile? ProfilePhoto { get; set; }

    public long RoleId { get; set; }

    public List<RoleViewModel> Roles { get; set; }

    public bool IsDeactived { get; set; }
}