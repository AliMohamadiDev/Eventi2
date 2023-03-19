using _0_Framework.Application;
using ServiceHost;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using _0_Framework.Application.ZarinPal;
using _0_Framework.Infrastructure;
using Eventi.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
var connectionString = builder.Configuration.GetConnectionString("EventiDB");
EventiBootstrapper.Configure(builder.Services, connectionString);

builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = _ => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Login");
        o.LogoutPath = new PathString("/Login");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea", b => b.RequireRole(new List<string> {Roles.Administration, Roles.BlogAdmin}));
    options.AddPolicy("Account", b => b.RequireRole(new List<string> {Roles.Administration}));

});

builder.Services.AddRazorPages()
    //.AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
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
