namespace Eventi.Infrastructure.Configuration.Permissions;

public class EventiPermissions
{
    // Event
    public const int GetEvent = 10;
    public const int CreateEvent = 11;
    public const int UpdateEvent = 12;

    // EventCategory
    public const int GetEventCategory = 20;
    public const int CreateEventCategory = 21;
    public const int UpdateEventCategory = 22;

    // Article
    public const int GetArticle = 30;
    public const int CreateArticle = 31;
    public const int UpdateArticle = 32;

    // ArticleCategory
    public const int GetArticleCategory = 40;
    public const int CreateArticleCategory = 41;
    public const int UpdateArticleCategory = 42;

    // Account
    public const int GetAccount = 50;
    public const int CreateAccount = 51;
    public const int UpdateAccount = 52;

    // Role
    public const int GetRole = 60;
    public const int CreateRole = 61;
    public const int UpdateRole = 62;
}