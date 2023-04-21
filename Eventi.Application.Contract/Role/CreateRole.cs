using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using _0_Framework.Infrastructure;

namespace Eventi.Application.Contract.Role;

public class CreateRole
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Name { get; set; }

    public List<int> Permissions { get; set; }
    public List<PermissionDto> MappedPermissions { get; set; }
}