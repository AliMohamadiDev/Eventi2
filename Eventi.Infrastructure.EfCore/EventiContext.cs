using Eventi.Domain.AccountAgg;
using Eventi.Domain.ArticleAgg;
using Eventi.Domain.ArticleCategoryAgg;
using Eventi.Domain.EventAgg;
using Eventi.Domain.EventCategoryAgg;
using Eventi.Domain.OrderAgg;
using Eventi.Domain.RoleAgg;
using Eventi.Domain.SlideAgg;
using Eventi.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore;

public class EventiContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventSubcategory> EventSubcategories { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Presenter> Presenters { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<DiscountCode> DiscountCodes { get; set; }
    public DbSet<EventPresenters> EventPresenters { get; set; }
    public DbSet<EventAccount> EventAccounts { get; set; }
    public DbSet<DepartmentAccount> DepartmentAccounts { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    //public DbSet<AccountTicket> AccountTickets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Slide> Slides { get; set; }

    public EventiContext(DbContextOptions<EventiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(EventMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}