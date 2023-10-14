using Microsoft.EntityFrameworkCore;
using PlatformServiceCore.Domain.RepositoryContracts;
using PlatformServiceCore.Services;
using PlatformServiceCore.ServicesContracts;
using PlatformServiceCore.SyncDataServices.Http;
using PlatformServiceInfrastructure;
using PlatformServiceInfrastructure.DBContext;
using PlatformServiceUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PlatformDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPlatformRepo, PlatformRepository>();
builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
var app = builder.Build();

// Configure the HTTP request pipeline.
Console.WriteLine(app.Configuration["DefaultUrl"]);

app.UseAuthorization();

app.MapControllers();

PrepData.PrepPopulation(app);

app.Run();
