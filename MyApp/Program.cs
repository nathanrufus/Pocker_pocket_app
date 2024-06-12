using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokerPocket.Data;
using PokerPocket.Services;
using PokerPocket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using PokerPocket.Services.Implementations;
using PokerPocket.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies; // Add this line to import CookieAuthentication
using Microsoft.AspNetCore.Http; // Add this line to import HttpContext
using System;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddSignalR(); // Add SignalR service

// Configure file upload handling
builder.Services.Configure<MvcOptions>(options =>
{
    options.MaxModelBindingCollectionSize = 1024 * 1024 * 10; // 10 MB
});

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "YourCookieName";
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.LogoutPath = "/Account/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set your desired expiration time
        options.SlidingExpiration = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Add authentication middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "games",
    pattern: "Games/{action=Index}/{id?}",
    defaults: new { controller = "Game", action = "Index" });

app.MapControllerRoute(
    name: "tournaments",
    pattern: "Tournaments/{action=Index}/{id?}",
    defaults: new { controller = "Tournament", action = "Index" });

app.MapControllerRoute(
    name: "profile",
    pattern: "Profile/{action=Index}/{id?}",
    defaults: new { controller = "Profile", action = "Index" });


app.MapHub<ChatHub>("/chatHub"); // Map SignalR Hub

app.Run();
