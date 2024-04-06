using ADSProject.Models;
using System.Reflection;

namespace ADSProject.Interfaces
{
    public interface IProfesor
    {
        public int AgregarProfesor (Profesor Profesor);
        public int ActualizarProfesor(int idProfesor, Profesor Profesor);
        public bool EliminarProfesor(int idProfesor);
        public List<Profesor> ObtenerTodosLosProfesores();
        public Profesor ObtenerProfesoresPorID(int idProfesor);
    }
}


