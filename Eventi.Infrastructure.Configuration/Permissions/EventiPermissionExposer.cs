using _0_Framework.Infrastructure;

namespace Eventi.Infrastructure.Configuration.Permissions;

public class EventiPermissionExposer : IPermissionExposer
{
    public Dictionary<string, List<PermissionDto>> Expose()
    {
        return new Dictionary<string, List<PermissionDto>>
        {
            {
                "Event", new List<PermissionDto>
                {
                    new(EventiPermissions.GetEvent, "GetEvent"),
                    new(EventiPermissions.CreateEvent, "CreateEvent"),
                    new(EventiPermissions.UpdateEvent, "UpdateEvent")
                }
            },
            {
                "EventCategory", new List<PermissionDto>
                {
                    new(EventiPermissions.GetEventCategory, "GetEventCategory"),
                    new(EventiPermissions.CreateEventCategory, "CreateEventCategory"),
                    new(EventiPermissions.UpdateEventCategory, "UpdateEventCategory")
                }
            },
            {
                "Article", new List<PermissionDto>
                {
                    new(EventiPermissions.GetArticle, "GetArticle"),
                    new(EventiPermissions.CreateArticle, "CreateArticle"),
                    new(EventiPermissions.UpdateArticle, "UpdateArticle")
                }
            },
            {
                "ArticleCategory", new List<PermissionDto>
                {
                    new(EventiPermissions.GetArticleCategory, "GetArticleCategory"),
                    new(EventiPermissions.CreateArticleCategory, "CreateArticleCategory"),
                    new(EventiPermissions.UpdateArticleCategory, "UpdateArticleCategory")
                }
            },
            {
                "AccountAccount", new List<PermissionDto>
                {
                    new(EventiPermissions.GetAccount, "GetAccount"),
                    new(EventiPermissions.CreateAccount, "CreateAccount"),
                    new(EventiPermissions.UpdateAccount, "UpdateAccount")
                }
            },
            {
                "Role", new List<PermissionDto>
                {
                    new(EventiPermissions.GetRole, "GetRole"),
                    new(EventiPermissions.CreateRole, "CreateRole"),
                    new(EventiPermissions.UpdateRole, "UpdateRole")
                }
            }
        };
    }
}