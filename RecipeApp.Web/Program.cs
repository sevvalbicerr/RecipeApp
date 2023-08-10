using AspNetCore.Identity.Extensions;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Core.Models;
using RecipeApp.Dal.DbContexts;
using RecipeApp.Web.Modules;
using System.Reflection;
using NLayer.Service.Mapping;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddIdentityWithExt();
builder.Services.AddMemoryCache();

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
});

builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder= new CookieBuilder();
    cookieBuilder.Name= "AppCookie";

    opt.LoginPath = new PathString("/Home/SignIn");
    opt.Cookie=cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
    
});


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
