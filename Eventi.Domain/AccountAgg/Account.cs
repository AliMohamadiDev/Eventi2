using Eventi.Domain.EventAgg;
using Eventi.Domain.RoleAgg;

namespace Eventi.Domain.AccountAgg;

public class Account
{
    public long Id { get; private set; }
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public string? State { get; private set; }
    public string? City { get; private set; }
    public string Mobile { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string? ProfilePhoto { get; private set; }
    public DateTime? Birthday { get; private set; }
    public DateTime CreationDate { get; private set; }

    public long RoleId { get; private set; }
    public Role Role { get; private set; }

    //public List<Event> MyEvents { get; private set; } = new();
    public List<AccountTicket> AccountTickets { get; private set; } = new();
    public List<DepartmentAccount> DepartmentAccounts { get; private set; } = new();

    protected Account()
    {
    }

    public Account(string firstname, string lastname, string? state, string? city, string mobile, string? email,
        string password, string? profilePhoto, DateTime? birthday, long roleId)
    {
        Firstname = firstname;
        Lastname = lastname;
        State = state;
        City = city;
        Mobile = mobile;
        Email = email;
        Password = password;
        ProfilePhoto = profilePhoto;
        Birthday = birthday;

        RoleId = roleId;
        if (roleId == 0)
        {
            RoleId = 2;
        }

        CreationDate = DateTime.Now;
    }

    public void Edit(string firstname, string lastname, string? state, string? city, string mobile, string? email,
        string? profilePhoto, DateTime? birthday, long roleId)
    {
        Firstname = firstname;
        Lastname = lastname;
        State = state;
        City = city;
        Mobile = mobile;
        Email = email;
        Birthday = birthday;
        if (!string.IsNullOrWhiteSpace(profilePhoto))
        {
            ProfilePhoto = profilePhoto;
        }

        RoleId = roleId;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }
}