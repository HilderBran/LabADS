using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IMateria
    {
        public int AgregarMateria(Materia Materia);
        public int ActualizarMateria(int idMateria, Materia Materia);
        public bool EliminarMateria(int idMateria);
        public List<Materia> ObtenerTodasLasMaterias();
        public Materia ObtenerMateriasPorID(int idMateria);
    }
}
