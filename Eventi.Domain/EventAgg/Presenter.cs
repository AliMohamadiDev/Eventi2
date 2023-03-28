namespace Eventi.Domain.EventAgg;

public class Presenter
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Logo { get; private set; }
    public string LogoTitle { get; private set; }
    public string LogoAlt { get; private set; }
    public string? Website { get; private set; }
    public string? Number { get; private set; }
    public string? Policy { get; private set; }
    public string? Description { get; private set; }
    public string Slug { get; private set; }
    public DateTime CreationDate { get; private set; }
    public List<EventPresenters> EventPresenters { get; private set; } = new();

    protected Presenter()
    {
    }

    public Presenter(string name, string logo, string logoTitle, string logoAlt, string? website, string? number, string? policy, string? description, string slug)
    {
        Name = name;
        Logo = logo;
        LogoTitle = logoTitle;
        LogoAlt = logoAlt;
        Website = website;
        Number = number;
        Policy = policy;
        Description = description;
        Slug = slug;
        CreationDate = DateTime.Now;
    }

    public void Edit(string name, string logo, string logoTitle, string logoAlt, string? website, string? number, string? policy, string? description, string slug)
    {
        Name = name;
        LogoTitle = logoTitle;
        LogoAlt = logoAlt;
        Website = website;
        Number = number;
        Policy = policy;
        Description = description;
        Slug = slug;

        if (!string.IsNullOrWhiteSpace(logo))
            Logo = logo;
    }

}