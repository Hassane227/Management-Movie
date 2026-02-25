using Microsoft.EntityFrameworkCore; 
using Movies.Infrastructure;
using Movies.Application;
using Movies.Presentation.Modules;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MoviesDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
  b => b.MigrationsAssembly("Movies.Infrastructure")
  ));
builder.Services.AddApplication();


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
app.AddMoviesEndpoints();

app.Run();
