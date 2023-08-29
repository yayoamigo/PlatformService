using Microsoft.EntityFrameworkCore;
using PlatformServiceCore.Domain.RepositoryContracts;
using PlatformServiceInfrastructure;
using PlatformServiceInfrastructure.DBContext;
using PlatformServiceUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PlatformDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPlatformRepo, PlatformRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepData.PrepPopulation(app);

app.Run();
