using Final_project_2.Models;
using Final_project_2.Repository;
using Final_project_2.Services;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using EmailVerification.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using NETCore.MailKit.Core;
using EmailVerification.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NuGet.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Final_project_2.ActionFilter;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => {
    options.Filters.Add(new AddJwtTokenFilter());
});

builder.Services.AddSession();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(i => 
//{ 
//    i.LoginPath = "/Access/Login";
//    i.ExpireTimeSpan = TimeSpan.FromMinutes(15);
//});
var configuration = builder.Configuration;


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddDbContext<TourismDbcontext>(options => options.UseSqlServer("server=DESKTOP-JP3GS28\\SQLEXPRESS;database=Tourism;TrustServerCertificate=True;Trusted_Connection=true;Multiple Active Result Sets=True;"));
builder.Services.AddScoped(typeof(ITourismRepository<>), typeof(Repository<>));

builder.Services.Configure<IdentityOptions>(
    o => o.SignIn.RequireConfirmedEmail = true
    );

var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig!);

builder.Services.AddScoped<IEmailServices, EmailServices>();
//builder.Services.AddIdentity<Person, IdentityRole>()
//        .AddEntityFrameworkStores<Tourism>()
//        .AddDefaultTokenProviders();

//builder.Services.AddScoped(typeof(RepositoryServices<>));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Use(async (context, next) =>
{
    string cookie = string.Empty;
    if (context.Request.Cookies.TryGetValue("Language", out cookie))
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie);
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie);
    }
    else
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
    }
    await next.Invoke();
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();







