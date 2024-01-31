using Microsoft.EntityFrameworkCore;
using WebApplicationTask.Models;
using WebApplicationTask.SettlementRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ISettlementRepository, SettlementRepository>();


builder.Services.AddDbContext<SettlementDBContext>(options =>
{
    IConfiguration configuration = builder.Configuration;
    options.UseSqlServer(configuration.GetConnectionString("DB"));
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
