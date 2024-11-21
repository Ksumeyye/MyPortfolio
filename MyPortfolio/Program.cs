using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient.Server;
using System.Diagnostics;
using System.Threading;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) //// Kimlik do�rulama i�in cookie tabanl� oturum a�ma i�lemini ekledim
    .AddCookie(options =>
    {
        // Login yolunu belirledim
        options.LoginPath = "/LogIn/Index/"; // Kullan�c� giri� yapacak sayfa
        options.AccessDeniedPath = "/LogIn/Index"; // Eri�im reddedildi sayfas�
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

app.UseAuthentication(); //Kimlik Do�rulama ekledim
app.UseAuthorization(); //Yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //// HTTP istekleri i�in routing yap�land�rmas�

app.Run();
