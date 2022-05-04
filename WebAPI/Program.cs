using Application;
using Application.Interfaces;
using Identity;
using Identity.Context;
using Identity.Models;
using Identity.Seeds;
using Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


//CONFIGURACION PARA USAR EL PROYECTO IDENTITY Y INSTANCIAR LOS ROLES Y USUARIOS UNA VEZ EL PROGRAMA COPILE



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceInfrastructure(configuration);
builder.Services.AddIdentityInfrastructure(configuration);

builder.Services.AddApplicationLayer();

builder.Services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseMySql(
               configuration.GetConnectionString("IdentityConnection"), new MySqlServerVersion(new Version()), b =>
               {
                   b.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName);
               }));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});


var app = builder.Build();

//LLENAR los usuarios y roles
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

async void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        try
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await DefaultRoles.SeedAsync(userManager, roleManager);
            await DefaultAdminUser.SeedAsync(userManager, roleManager);
            await DefaultBasicUser.SeedAsync(userManager, roleManager);
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.MapControllers();


app.Run();
