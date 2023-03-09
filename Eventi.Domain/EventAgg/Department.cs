namespace Eventi.Domain.EventAgg;

public class Department
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public long NationalCode { get; private set; }
    public long PostalCode { get; private set; }
    public string Address { get; private set; }
    public DateTime CreationDate { get; private set; }
    public List<Event> Events { get; private set; } = new();
    //public List<DepartmentAccount> DepartmentAccounts { get; private set; }

    protected Department()
    {
    }

    public Department(string name, long nationalCode, long postalCode, string address)
    {
        Name = name;
        NationalCode = nationalCode;
        PostalCode = postalCode;
        Address = address;
        CreationDate = DateTime.Now;
    }
    
    public void Edit(string name, long nationalCode, long postalCode, string address)
    {
        Name = name;
        NationalCode = nationalCode;
        PostalCode = postalCode;
        Address = address;
    }
}