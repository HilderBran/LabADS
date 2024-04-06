using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor

    {
        private List<Profesor> lstProfesor = new List<Profesor>
        {
            new Profesor {IdProfesor = 1, NombreProfesor = "JUAN CARLOS",
            ApellidoProfesor = "PEREZ SOSA", Email = ""}
        };

        public int ActualizarProfesor(int idProfesor, Profesor Profesor)
        {
            try
            {
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                lstProfesor[indice] = Profesor;
                lstProfesor[indice].IdProfesor = idProfesor;

                return idProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarProfesor(Profesor Profesor)
        {
            try
            {
                if (lstProfesor.Count > 0)
                {
                    Profesor.IdProfesor = lstProfesor.Last().IdProfesor + 1;
                }
                lstProfesor.Add(Profesor);

                return Profesor.IdProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                lstProfesor.RemoveAt(indice);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Profesor ObtenerProfesoresPorID(int idProfesor)
        {
            try
            {
                Profesor Profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);

                return Profesor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                return lstProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
