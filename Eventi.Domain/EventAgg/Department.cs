namespace Eventi.Domain.EventAgg;

public class Department
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Logo { get; private set; }
    public string LogoTitle { get; private set; }
    public string LogoAlt { get; private set; }
    public long NationalCode { get; private set; }
    public long PostalCode { get; private set; }
    public string Address { get; private set; }
    public string Slug { get; private set; }
    public string? Description { get; private set; }
    public DateTime CreationDate { get; private set; }
    public List<Event> Events { get; private set; } = new();
    public List<DepartmentAccount> DepartmentAccounts { get; private set; } = new();

    protected Department()
    {
    }

    public Department(string name, long nationalCode, long postalCode, string address, string logo, string logoAlt, string logoTitle, string slug, string description)
    {
        Name = name;
        NationalCode = nationalCode;
        PostalCode = postalCode;
        Address = address;
        Logo = logo;
        LogoAlt = logoAlt;
        LogoTitle = logoTitle;
        Slug = slug;
        Description = description;
        CreationDate = DateTime.Now;
    }
    
    public void Edit(string name, long nationalCode, long postalCode, string address, string logo, string logoAlt, string logoTitle, string slug, string description)
    {
        Name = name;
        NationalCode = nationalCode;
        PostalCode = postalCode;
        Address = address;
        Slug = slug;
        Description = description;
        LogoAlt = logoAlt;
        LogoTitle = logoTitle;
        
        if (!string.IsNullOrWhiteSpace(logo))
            Logo = logo;
    }
}