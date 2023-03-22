global using petShop.Models;
global using petShop.Controllers;
global using petShop.Data;
global using petShop.Repository;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
global using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using petShop.Helpers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddControllers();
        string mySqlConnection = builder.Configuration.GetConnectionString("petshop");

        builder.Services.AddDbContext<PetShopContext>(opt =>
        {
            opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
        });

        builder.Services.AddScoped<IPetRepository, PetRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddSession();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<ISessao, Sessao>();
        builder.Services.AddSession(o =>
        {
            o.Cookie.HttpOnly = true;
            o.Cookie.IsEssential = true;
        });

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        /* app.UseMvc(routes => {
            routes.MapAreaRoute(name: "Pets", areaName: "mvcPetsRoute",
                                template: "{area: exists}/{Controller=Pets}/{action=VerDeletar}/{id?}");

            routes.MapAreaRoute(name: "default", areaName: "default",
                                template: "{controller=Home}/{action=Index}");
        }); */

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Authentication}/{action=Registrar}/{id?}");

        app.Run();
    }
}