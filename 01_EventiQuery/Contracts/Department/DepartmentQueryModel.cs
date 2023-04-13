using _01_EventiQuery.Contracts.Event;

namespace _01_EventiQuery.Contracts.Department;

public class DepartmentQueryModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long NationalCode { get; set; }
    public long PostalCode { get; set; }
    public string Address { get; set; }

    public List<EventQueryModel> Events { get; set; }
}