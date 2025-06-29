﻿using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using _0_Framework.Infrastructure;
using _01_EventiQuery.Contracts.Account;
using _01_EventiQuery.Contracts.Article;
using _01_EventiQuery.Contracts.ArticleCategory;
using _01_EventiQuery.Contracts.Common;
using _01_EventiQuery.Contracts.Department;
using _01_EventiQuery.Contracts.Event;
using _01_EventiQuery.Contracts.EventCategory;
using _01_EventiQuery.Contracts.Presenter;
using _01_EventiQuery.Contracts.Slide;
using _01_EventiQuery.Query;
using Eventi.Application;
using Eventi.Application.Contract.Account;
using Eventi.Application.Contract.Article;
using Eventi.Application.Contract.ArticleCategory;
using Eventi.Application.Contract.Department;
using Eventi.Application.Contract.DiscountCode;
using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventSubcategory;
using Eventi.Application.Contract.Order;
using Eventi.Application.Contract.Presenter;
using Eventi.Application.Contract.Role;
using Eventi.Application.Contract.Slide;
using Eventi.Application.Contract.Ticket;
using Eventi.Domain.AccountAgg;
using Eventi.Domain.ArticleAgg;
using Eventi.Domain.ArticleCategoryAgg;
using Eventi.Domain.EventAgg;
using Eventi.Domain.EventCategoryAgg;
using Eventi.Domain.OrderAgg;
using Eventi.Domain.RoleAgg;
using Eventi.Domain.SlideAgg;
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
        services.AddTransient<IAccountQuery, AccountQuery>();

        services.AddTransient<IRoleApplication, RoleApplication>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        
        services.AddTransient<IEventSubcategoryApplication, EventSubcategoryApplication>();
        services.AddTransient<IEventSubcategoryRepository, EventSubcategoryRepository>();

        services.AddTransient<IDepartmentApplication, DepartmentApplication>();
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        services.AddTransient<IDepartmentQuery, DepartmentQuery>();

        services.AddTransient<IPresenterApplication, PresenterApplication>();
        services.AddTransient<IPresenterRepository, PresenterRepository>();

        services.AddTransient<ITicketApplication, TicketApplication>();
        services.AddTransient<ITicketRepository, TicketRepository>();
        
        services.AddTransient<IDiscountCodeApplication, DiscountCodeApplication>();
        services.AddTransient<IDiscountCodeRepository, DiscountCodeRepository>();

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

        services.AddTransient<IOrderApplication, OrderApplication>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        
        services.AddTransient<ISlideApplication, SlideApplication>();
        services.AddTransient<ISlideRepository, SlideRepository>();
        services.AddTransient<ISlideQuery, SlideQuery>();

        services.AddTransient<SeedData>();
        services.AddTransient<IAuthHelper, AuthHelper>();
        services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();

        services.AddTransient<IIndexQuery, IndexQuery>();

        services.AddTransient<IPermissionExposer, EventiPermissionExposer>();

        services.AddDbContext<EventiContext>(x => x.UseSqlServer(connectionString).EnableSensitiveDataLogging());
    }
}