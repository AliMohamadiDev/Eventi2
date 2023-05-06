using _01_EventiQuery.Contracts.Event;

namespace _01_EventiQuery.Contracts.Department;

public class DepartmentQueryModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long NationalCode { get; set; }
    public long PostalCode { get; set; }
    public string Address { get; set; }
    public string Logo { get; set; }
    public string LogoTitle { get; set; }
    public string LogoAlt { get; set; }
    public string Slug { get; set; }

    public List<EventQueryModel> Events { get; set; }
}