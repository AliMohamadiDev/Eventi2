namespace Eventi.Application.Contract.Slide;

public class SlideViewModel
{
    public long Id { get; set; }
    public string Picture { get; set; }
    public bool IsRemoved { get; set; }
    public string CreationDate { get; set; }
    public string Link { get; set; }
}