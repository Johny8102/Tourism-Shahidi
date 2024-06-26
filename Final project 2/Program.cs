using Final_project_2.Models;
using Final_project_2.Repository;
using Final_project_2.Services;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(i => 
{
    i.LoginPath = "/Access/Login";
    i.ExpireTimeSpan = TimeSpan.FromMinutes(15);
});

IConfiguration configuration = null;

builder.Services.AddDbContext<Tourism>(options => options.UseSqlServer("server=DESKTOP-JP3GS28\\SQLEXPRESS;database=Tourism;TrustServerCertificate=True;Trusted_Connection=true;Multiple Active Result Sets=True;"));
builder.Services.AddScoped(typeof(ITourismRepository<>), typeof(Repository<>));
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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
