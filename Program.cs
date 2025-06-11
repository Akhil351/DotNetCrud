using crud.Data;
using Microsoft.EntityFrameworkCore;
using crud.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<Db>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure HTTPS redirection
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();