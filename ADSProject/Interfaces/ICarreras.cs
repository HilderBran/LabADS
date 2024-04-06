using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface ICarreras
    {
        public int AgregarCarrera(Carreras carreras);
        public int ActualizarCarrera(int idCarrera, Carreras carreras);
        public bool EliminarCarrera(int idCarrera);
        public List<Carreras> ObtenerTodasLasCarreras();
        public Carreras ObtenerCarreraPorID(int idCarrera);
    }
}
