namespace _0_Framework.Application;

public class AuthViewModel
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public string Role { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public List<int> Permissions { get; set; }
    public string? ProfilePhoto { get; set; }

    public AuthViewModel()
    {
    }

    public AuthViewModel(long id, long roleId, string firstname, string lastname, string email, List<int> permissions, string? profilePhoto)
    {
        Id = id;
        RoleId = roleId;
        Firstname = firstname;
        Lastname = lastname;
        Permissions = permissions;
        ProfilePhoto = profilePhoto;
    }

}