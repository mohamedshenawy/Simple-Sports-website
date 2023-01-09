using AutoMapper;
using Data_Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repos;
using System;
using System.IO;
using ViewModels;

var bulider = WebApplication.CreateBuilder(args);
bulider.Services.AddControllersWithViews();
bulider.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(bulider.Configuration.GetConnectionString("MyconnectionString"));
});
//auto mapper reg
bulider.Services.AddAutoMapper(typeof(Program));

bulider.Services.AddScoped<DbContext, Context>();
bulider.Services.AddScoped(typeof(IModelRepo<>), typeof(ModelRepo<>));
bulider.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
bulider.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Context>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);
bulider.Services.AddAuthorization();

bulider.Services.ConfigureApplicationCookie(op =>
{
    op.Cookie.Name = "AspNetCore.Identity.Application";
    op.ExpireTimeSpan = TimeSpan.FromDays(1);
    op.SlidingExpiration = true;
});
                

var app = bulider.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.Environment.ContentRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
app.UseStaticFiles();
app.UseCors(opt=>opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Account}/{action=Login}/{id?}");
    endpoints.MapControllers();
});


app.Run();


#region .net 5 program.cs
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Hosting;


//namespace Sports_Website
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}
#endregion