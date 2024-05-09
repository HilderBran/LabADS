using ADSProject.Models;
using ADSProject.Interfaces;
using ADSProject.Database;

namespace ADSProject.Repositories
{
    public class CarreraRepository : Interfaces.ICarreras
    {
        /*private List<Carreras> lstCarreras = new List<Carreras>
        {
            new Carreras {IdCarrera = 1, NombreCarrera= "ING. EN SISTEMAS COMPUTACIONALES",
            CodigoCarrera = "ISC"}
        };*/

        private readonly ApplicationDBContext applicationDBContext;

        public CarreraRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public int ActualizarCarrera(int idCarrera, Carreras carreras)
        {
            try
            {
                /*int indice = lstCarreras.FindIndex(tmp => tmp.IdCarrera == idCarrera);

                lstCarreras [indice] = carreras;
                lstCarreras[indice].IdCarrera = idCarrera;*/

                var item = applicationDBContext.carreras.FirstOrDefault(x => x.IdCarrera == idCarrera);

                applicationDBContext.Entry(item).CurrentValues.SetValues(carreras);

                applicationDBContext.SaveChanges();

                return idCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarCarrera(Carreras carreras)
        {
            try
            {
                /*if (lstCarreras.Count > 0)
                {
                    carreras.IdCarrera = lstCarreras.Last().IdCarrera+ 1;
                }
                lstCarreras.Add(carreras);*/

                applicationDBContext.carreras.Add(carreras);
                applicationDBContext.SaveChanges();

                return carreras.IdCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                /*int indice = lstCarreras.FindIndex(tmp => tmp.IdCarrera == idCarrera);

                lstCarreras.RemoveAt(indice);*/

                var item = applicationDBContext.carreras.FirstOrDefault(x => x.IdCarrera == idCarrera);

                applicationDBContext.carreras.Remove(item);

                applicationDBContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Carreras ObtenerCarreraPorID(int idCarrera)
        {
            try
            {
                /*Carreras carreras= lstCarreras.FirstOrDefault(tmp => tmp.IdCarrera == idCarrera);*/

                var carreras = applicationDBContext.carreras.FirstOrDefault(x => x.IdCarrera == idCarrera);

                return carreras;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Carreras> ObtenerTodasLasCarreras()
        {
            try
            {
                //return lstCarreras;

                return applicationDBContext.carreras.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
