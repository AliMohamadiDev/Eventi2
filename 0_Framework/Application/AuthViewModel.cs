namespace _0_Framework.Application;

public class AuthViewModel
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public string Role { get; set; }
    public string? Fullname { get; set; }
    public string? Email { get; set; }
    public List<int> Permissions { get; set; }
    public string? ProfilePhoto { get; set; }

    public AuthViewModel()
    {
    }

    public AuthViewModel(long id, long roleId, string fullname, string? email, List<int> permissions, string? profilePhoto)
    {
        Id = id;
        RoleId = roleId;
        Fullname = fullname;
        Email = email;
        Permissions = permissions;
        ProfilePhoto = profilePhoto;
    }

}