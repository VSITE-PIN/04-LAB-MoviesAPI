using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Swagger (već je u templatu, ostavljamo)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext – EF Core + connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnString")
        ?? throw new InvalidOperationException("Connection string DefaultConnString not found.")));

// Registracija MoviesService za Dependency Injection
builder.Services.AddScoped<MoviesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
