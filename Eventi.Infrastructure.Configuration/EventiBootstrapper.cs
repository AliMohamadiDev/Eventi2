using _0_Framework.Infrastructure;
using _01_EventiQuery.Contracts.Article;
using _01_EventiQuery.Contracts.ArticleCategory;
using _01_EventiQuery.Contracts.Event;
using _01_EventiQuery.Contracts.EventCategory;
using _01_EventiQuery.Contracts.Presenter;
using _01_EventiQuery.Query;
using Eventi.Application;
using Eventi.Application.Contract.Account;
using Eventi.Application.Contract.Article;
using Eventi.Application.Contract.ArticleCategory;
using Eventi.Application.Contract.Department;
using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventCategory;
using Eventi.Application.Contract.EventInfo;
using Eventi.Application.Contract.EventSubcategory;
using Eventi.Application.Contract.Presenter;
using Eventi.Application.Contract.Role;
using Eventi.Application.Contract.Ticket;
using Eventi.Domain.AccountAgg;
using Eventi.Domain.ArticleAgg;
using Eventi.Domain.ArticleCategoryAgg;
using Eventi.Domain.EventAgg;
using Eventi.Domain.EventCategoryAgg;
using Eventi.Domain.RoleAgg;
using Eventi.Infrastructure.Configuration.Permissions;
using Eventi.Infrastructure.EfCore;
using Eventi.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eventi.Infrastructure.Configuration;

public class EventiBootstrapper
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IAccountApplication, AccountApplication>();
        services.AddTransient<IAccountRepository, AccountRepository>();

        services.AddTransient<IRoleApplication, RoleApplication>();
        services.AddTransient<IRoleRepository, RoleRepository>();

        services.AddTransient<IEventCategoryApplication, EventCategoryApplication>();
        services.AddTransient<IEventCategoryRepository, EventCategoryRepository>();

        services.AddTransient<IEventSubcategoryApplication, EventSubcategoryApplication>();
        services.AddTransient<IEventSubcategoryRepository, EventSubcategoryRepository>();

        services.AddTransient<IDepartmentApplication, DepartmentApplication>();
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();

        services.AddTransient<IPresenterApplication, PresenterApplication>();
        services.AddTransient<IPresenterRepository, PresenterRepository>();

        services.AddTransient<ITicketApplication, TicketApplication>();
        services.AddTransient<ITicketRepository, TicketRepository>();

        services.AddTransient<IEventInfoApplication, EventInfoApplication>();
        services.AddTransient<IEventInfoRepository, EventInfoRepository>();

        services.AddTransient<IEventApplication, EventApplication>();
        services.AddTransient<IEventRepository, EventRepository>();

        services.AddTransient<IEventCategoryQuery, EventCategoryQuery>();
        services.AddTransient<IPresenterQuery, PresenterQuery>();
        services.AddTransient<IEventQuery, EventQuery>();

        services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
        services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

        services.AddTransient<IArticleApplication, ArticleApplication>();
        services.AddTransient<IArticleRepository, ArticleRepository>();

        services.AddTransient<IArticleQuery, ArticleQuery>();
        services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

        services.AddTransient<IPermissionExposer, EventiPermissionExposer>();

        services.AddDbContext<EventiContext>(x => x.UseSqlServer(connectionString), ServiceLifetime.Transient);
    }
}