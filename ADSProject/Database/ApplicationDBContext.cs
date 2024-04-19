using ADSProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ADSProject.Database
{
    public class ApplicationDBContext : DbContext
    {
        private IConfiguration configuration;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Estudiante> estudiantes { get; set; }
        public DbSet<Carreras> carreras { get; set; }
        public DbSet<Grupo> grupos { get; set; }
        public DbSet<Materia> materias{ get; set; }
        public DbSet<Profesor> profesores { get; set; }

    }
}
