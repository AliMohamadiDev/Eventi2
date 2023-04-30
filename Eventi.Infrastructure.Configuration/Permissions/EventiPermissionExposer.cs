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
                    new(EventiPermissions.GetEvent, "نمایش رویداد ها"),
                    new(EventiPermissions.CreateEvent, "ایجاد رویداد"),
                    new(EventiPermissions.UpdateEvent, "ویرایش رویداد")
                }
            },
            {
                "EventCategory", new List<PermissionDto>
                {
                    new(EventiPermissions.GetEventCategory, "نمایش موضوعات رویداد"),
                    new(EventiPermissions.CreateEventCategory, "ایجاد موضوع رویداد"),
                    new(EventiPermissions.UpdateEventCategory, "ویرایش موضوع رویداد")
                }
            },
            {
                "Article", new List<PermissionDto>
                {
                    new(EventiPermissions.GetArticle, "نمایش مقالات"),
                    new(EventiPermissions.CreateArticle, "ایجاد مقاله"),
                    new(EventiPermissions.UpdateArticle, "ویرایش مقاله")
                }
            },
            {
                "ArticleCategory", new List<PermissionDto>
                {
                    new(EventiPermissions.GetArticleCategory, "نمایش موضوعات مقالات"),
                    new(EventiPermissions.CreateArticleCategory, "ایجاد موضوع مقاله"),
                    new(EventiPermissions.UpdateArticleCategory, "ویرایش موضوع مقاله")
                }
            },
            {
                "AccountAccount", new List<PermissionDto>
                {
                    new(EventiPermissions.GetAccount, "نمایش حساب ها"),
                    new(EventiPermissions.CreateAccount, "ساخت حساب"),
                    new(EventiPermissions.UpdateAccount, "ویرایش حساب")
                }
            },
            {
                "Role", new List<PermissionDto>
                {
                    new(EventiPermissions.GetRole, "نمایش نقش"),
                    new(EventiPermissions.CreateRole, "ایجاد نقش"),
                    new(EventiPermissions.UpdateRole, "ویرایش نقش")
                }
            }
        };
    }
}