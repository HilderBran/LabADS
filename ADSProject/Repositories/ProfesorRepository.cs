using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Database;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor

    {
        /*private List<Profesor> lstProfesor = new List<Profesor>
        {
            new Profesor {IdProfesor = 1, NombreProfesor = "JUAN CARLOS",
            ApellidoProfesor = "PEREZ SOSA", Email = ""}
        };*/
        private readonly ApplicationDBContext applicationDBContext;

        public ProfesorRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public int ActualizarProfesor(int idProfesor, Profesor Profesor)
        {
            try
            {
                /*int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstProfesor[indice] = Profesor;
                lstProfesor[indice].IdProfesor = idProfesor;*/
                var item = applicationDBContext.profesores.FirstOrDefault(x => x.IdProfesor == idProfesor);
                applicationDBContext.Entry(item).CurrentValues.SetValues(Profesor);
                applicationDBContext.SaveChanges();

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
                /*if (lstProfesor.Count > 0)
                {
                    Profesor.IdProfesor = lstProfesor.Last().IdProfesor + 1;
                }
                lstProfesor.Add(Profesor);*/
                applicationDBContext.profesores.Add(Profesor);
                applicationDBContext.SaveChanges();

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
                //int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                //lstProfesor.RemoveAt(indice);
                var item = applicationDBContext.profesores.FirstOrDefault(x => x.IdProfesor == idProfesor);
                applicationDBContext.profesores.Remove(item);
                applicationDBContext.SaveChanges();

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
                //Profesor Profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);
                var profesor = applicationDBContext.profesores.FirstOrDefault(x => x.IdProfesor == idProfesor);

                return profesor;
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
                //return lstProfesor;
                return applicationDBContext.profesores.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
