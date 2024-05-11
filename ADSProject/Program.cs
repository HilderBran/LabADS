using ADSProject.Database;
using ADSProject.Interfaces;
using ADSProject.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de dependencias
builder.Services.AddScoped<IEstudiante, EstudianteRepository>();
builder.Services.AddScoped<ICarreras, CarreraRepository>();
builder.Services.AddScoped<IGrupo, GrupoRepository>();
builder.Services.AddScoped<IProfesor, ProfesorRepository>();
builder.Services.AddScoped<IMateria, MateriaRepository>();
builder.Services.AddDbContext<ApplicationDBContext>();

//Configurando CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configuration =>
    {
        configuration.WithOrigins(builder.Configuration["allowedOrigins"]!)
        .AllowAnyMethod().AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
