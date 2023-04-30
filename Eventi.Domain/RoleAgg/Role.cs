using Eventi.Domain.AccountAgg;

namespace Eventi.Domain.RoleAgg;

public class Role
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public List<Account> Accounts { get; set; } = new();
    public List<Permission> Permissions { get; set; } = new();

    public Role()
    {
    }

    public Role(string name, List<Permission> permissions)
    {
        Name = name;
        Permissions = permissions;
        Accounts = new List<Account>();
    }

    public void Edit(string name, List<Permission> permissions)
    {
        Name = name;
        Permissions = permissions;
    }
}