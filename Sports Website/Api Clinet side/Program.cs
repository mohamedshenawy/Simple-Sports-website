using Data_Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Repos;
using System.Text;

var bulider = WebApplication.CreateBuilder(args);

bulider.Services.AddControllers();

bulider.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_Clinet_side", Version = "v1" });
    c.AddSecurityDefinition("token", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = HeaderNames.Authorization,
        Scheme = "Bearer"
    });
});

bulider.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(bulider.Configuration.GetConnectionString("MyconnectionString"));

});

bulider.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Context>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);
bulider.Services.AddScoped<DbContext, Context>();
bulider.Services.AddScoped(typeof(IModelRepo<>), typeof(ModelRepo<>));
bulider.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
bulider.Services.AddCors(options => options.AddPolicy("Cors",
   builder =>
   {
       builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader();
   }));

// Start Configration of JWT
bulider.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false;
        opt.SaveToken = false;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = bulider.Configuration.GetValue<string>("jwt:Issuer"),
            ValidAudience = bulider.Configuration.GetValue<string>("jwt:Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(bulider.Configuration.GetValue<string>("jwt:key")))
        };
    });
// End Configration of JWT



var app = bulider.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api_Clinet_side v1"));
}

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();
app.UseRouting();

//app.UseAuthorization();
//app.UseCors("Cors");
app.UseCors("Cors");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();


#region .NET 5
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Api_Clinet_side
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
