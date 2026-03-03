using Microsoft.EntityFrameworkCore; 
using Movies.Infrastructure;
using Movies.Application;
using Movies.Presentation.Modules;
using Movies.Presentation.Handlers;
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
// il faut toujours ajouter le service de cors avant les autres services et aussi pour authoriser les requetes du frontend 
builder.Services.AddCors(p => p.AddPolicy("CorsPolicy",
    p => 
p.SetIsOriginAllowed(_ => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));  
builder.Services.AddApplication();
builder.Services.AddExceptionHandler<ExceptionHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();
app.AddMoviesEndpoints();

app.Run();
