using ADSProject.Models;
using ADSProject.Interfaces;
using ADSProject.Database;

namespace ADSProject.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
       /* private List<Estudiante> lstEstudiante = new List<Estudiante>
        {
            new Estudiante {IdEstudiante = 1, NombresEstudiante = "JUAN CARLOS",
            ApellidosEstudiante = "PEREZ SOSA", CodigoEstudiante = "PS24I04002",
            CorreoEstudiante = "PS24I04002@usonsonate.edu.sv"}
        };*/
       private readonly ApplicationDBContext applicationDBContext;

        public EstudianteRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try {
                //int indice = lstEstudiante.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);

               // lstEstudiante[indice] = estudiante;
              //  lstEstudiante[indice].IdEstudiante = idEstudiante;
              // 
                var item = applicationDBContext.estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDBContext.Entry(item).CurrentValues.SetValues(estudiante);
                applicationDBContext.SaveChanges();

                

                return idEstudiante;
            } catch (Exception) {
                throw;
            }
        }

       public int AgregarEstudiante(Estudiante estudiante)
        {
            try {
                /*if(lstEstudiante.Count > 0){
                    estudiante.IdEstudiante = lstEstudiante.Last().IdEstudiante +1;
                }
                lstEstudiante.Add(estudiante);*/
                applicationDBContext.estudiantes.Add(estudiante);
                applicationDBContext.SaveChanges();

                return estudiante.IdEstudiante;
            } catch (Exception){
                throw;
            }
        }

       public bool EliminarEstudiante(int idEstudiante)
        {
            try {
                //int indice = lstEstudiante.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                //lstEstudiante.RemoveAt(indice);

                var item = applicationDBContext.estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDBContext.estudiantes.Remove(item);
                applicationDBContext.SaveChanges();

                return true;
            } catch (Exception) {
                throw;
            }
        }

        public Estudiante ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                //Estudiante estudiante = lstEstudiante.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);

                var estudiante = applicationDBContext.estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                return estudiante;
            }
            catch (Exception)
            {

                throw;
            }
        }

       public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                //return lstEstudiante;
                return applicationDBContext.estudiantes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
