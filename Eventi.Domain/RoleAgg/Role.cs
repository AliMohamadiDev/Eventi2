using Eventi.Domain.AccountAgg;

namespace Eventi.Domain.RoleAgg;

public class Role
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public DateTime CreationDate { get; private set; } = DateTime.Now;
    public List<Account> Accounts { get; private set; } = new();
    public List<Permission> Permissions { get; private set; } = new();

    protected Role()
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