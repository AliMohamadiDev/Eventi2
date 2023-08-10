using _01_EventiQuery.Contracts.Event;

namespace _01_EventiQuery.Contracts.Presenter;

public class PresenterQueryModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string LogoTitle { get; set; }
    public string LogoAlt { get; set; }
    public string? Website { get; set; }
    public string? Number { get; set; }
    public string? Policy { get; set; }
    public string? Description { get; set; }
    public string Slug { get; set; }
    public int EventCount { get; set; }
    public List<EventQueryModel> Events { get; set; } = new();
}