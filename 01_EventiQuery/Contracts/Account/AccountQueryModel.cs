using _01_EventiQuery.Contracts.Event;
using Eventi.Application.Contract.Department;
using Eventi.Domain.OrderAgg;
using Eventi.Domain.RoleAgg;

namespace _01_EventiQuery.Contracts.Account;

public class AccountQueryModel
{
    public long Id { get; set; }
    public string Fullname { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string Mobile { get; set; }
    public string? Email { get; set; }
    public string? ProfilePhoto { get; set; }
    public DateTime? Birthday { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDeactived { get; set; }

    public long RoleId { get; set; }
    public Role Role { get; set; }

    public List<DepartmentViewModel> Departments { get; set; }

    public List<TicketQueryModel> Tickets { get; set; }
    public List<Order> Orders { get; set; } = new();

    //public List<Event> MyEvents { get; set; } = new();
}