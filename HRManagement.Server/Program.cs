using Microsoft.EntityFrameworkCore;
using HRMagnement.Server.Data;
using HRManagement.Contacts.Services;
using HRManagement.BussinessLogic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Automapper
builder.Services.AddAutoMapper(typeof(HRManagement.BussinessLogic.Mapping.EmployeeProfile).Assembly);

// Business logic services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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