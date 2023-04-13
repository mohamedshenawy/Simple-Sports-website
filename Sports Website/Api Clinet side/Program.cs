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
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                { 
                    Type = ReferenceType.SecurityScheme , 
                    Id = "Baerer"
                }
            },
            new string[] { }
        }
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
//bulider.Services.AddJWTTokenServices(bulider.Configuration);
bulider.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false;
        opt.SaveToken = false;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
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
app.UseCors("Cors");
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();


