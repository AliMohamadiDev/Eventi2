using _0_Framework.Application;
using ServiceHost;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using _0_Framework.Infrastructure;
using Eventi.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
var connectionString = builder.Configuration.GetConnectionString("EventiDB");
EventiBootstrapper.Configure(builder.Services, connectionString);

builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));

var seedData = builder.Services.BuildServiceProvider().GetRequiredService<SeedData>();
seedData.SeedDatabase();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = _ => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Login");
        o.LogoutPath = new PathString("/Logout");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea", b => b.RequireRole(new List<string> {Roles.Administration, Roles.BlogAdmin, Roles.Presenter}));
    options.AddPolicy("Account", b => b.RequireRole(new List<string> {Roles.Administration}));
    options.AddPolicy("AdminAction", b => b.RequireRole(new List<string> {Roles.Administration}));
    options.AddPolicy("Event", b => b.RequireRole(new List<string> {Roles.Administration, Roles.Presenter}));
    options.AddPolicy("Blog", b => b.RequireRole(new List<string> {Roles.Administration, Roles.BlogAdmin}));
});

builder.Services.AddRazorPages()
    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Events", "Event");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Blog", "Blog");
        options.Conventions.AuthorizeAreaFolder("Administration", "/SiteSettings", "AdminAction");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
