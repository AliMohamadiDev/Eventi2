using Eventi.Domain.EventAgg;
using Eventi.Domain.OrderAgg;
using Eventi.Domain.RoleAgg;

namespace Eventi.Domain.AccountAgg;

public class Account
{
    public long Id { get; set; }
    public string Fullname { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string Mobile { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public string? ProfilePhoto { get; set; }
    public DateTime? Birthday { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDeactived { get; set; }

    public long RoleId { get; set; }
    public Role Role { get; set; }

    //public List<Event> MyEvents { get; set; } = new();
    //public List<AccountTicket> AccountTickets { get; set; } = new();
    public List<DepartmentAccount> DepartmentAccounts { get; set; } = new();
    public List<Order> Orders { get; set; } = new();

    public Account()
    {
    }

    public Account(string fullname, string? state, string? city, string mobile, string? email,
        string password, string? profilePhoto, DateTime? birthday, long roleId)
    {
        Fullname = fullname;
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
        IsDeactived = false;
    }

    public void Edit(string firstname, string? state, string? city, string mobile, string? email,
        string? profilePhoto, DateTime? birthday, long roleId)
    {
        Fullname = firstname;
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

    public void Deactivate()
    {
        IsDeactived = true;
    }

    public void Activate()
    {
        IsDeactived = false;
    }
}