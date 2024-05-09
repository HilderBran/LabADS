using ADSProject.Database;
using ADSProject.Interfaces;
using ADSProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEstudiante, EstudianteRepository>();
builder.Services.AddScoped<ICarreras, CarreraRepository>();
builder.Services.AddScoped<IGrupo, GrupoRepository>();
builder.Services.AddScoped<IProfesor, ProfesorRepository>();
builder.Services.AddScoped<IMateria, MateriaRepository>();
builder.Services.AddDbContext<ApplicationDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
