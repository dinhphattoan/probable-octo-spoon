using Microsoft.EntityFrameworkCore;
using HRMagnement.Server.Data;
using HRManagement.Server.Repositories.Base;
using HRMagnement.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
builder.Services.AddScoped<IGenericRepository<JobPoster>, GenericRepository<JobPoster>>();
builder.Services.AddScoped<IGenericRepository<NewApplicant>, GenericRepository<NewApplicant>>();
builder.Services.AddScoped<IGenericRepository<EmployeeContact>, GenericRepository<EmployeeContact>>();



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();