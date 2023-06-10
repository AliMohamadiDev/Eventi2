namespace Eventi.Domain.SlideAgg;

public class Slide
{
    public long Id { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string Picture { get; private set; }
    public string? PictureAlt { get; private set; }
    public string? PictureTitle { get; private set; }
    public string Link { get; private set; }
    public bool IsRemoved { get; private set; }

    public Slide(string picture, string pictureAlt, string pictureTitle, string link)
    {
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Link = link;
        IsRemoved = false;
        CreationDate = DateTime.Now;
    }

    public void Edit(string picture, string pictureAlt, string pictureTitle, string link)
    {
        if (!string.IsNullOrWhiteSpace(picture))
            Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Link = link;
    }

    public void Remove()
    {
        IsRemoved = true;
    }

    public void Restore()
    {
        IsRemoved = false;
    }
}