namespace _01_EventiQuery.Contracts.Event;

public class AccountSideQueryModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long NationalCode { get; set; }
    public long PostalCode { get; set; }
    public string Address { get; set; }
    public bool IsReal { get; set; }
    public List<EventQueryModel> Events { get; set; }
}