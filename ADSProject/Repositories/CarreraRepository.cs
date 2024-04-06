using ADSProject.Models;
using ADSProject.Interfaces;

namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarreras
    {
        private List<Carreras> lstCarreras = new List<Carreras>
        {
            new Carreras {IdCarrera = 1, NombreCarrera= "INGENIERIA EN SISTEMAS COMPUTACIONALES",
            CodigoCarrera = "ISC"}
        };

        public int ActualizarCarrera(int idCarrera, Carreras carreras)
        {
            try
            {
                int indice = lstCarreras.FindIndex(tmp => tmp.IdCarrera == idCarrera);

                lstCarreras [indice] = carreras;
                lstCarreras[indice].IdCarrera = idCarrera;

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
                if (lstCarreras.Count > 0)
                {
                    carreras.IdCarrera = lstCarreras.Last().IdCarrera+ 1;
                }
                lstCarreras.Add(carreras);

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
                int indice = lstCarreras.FindIndex(tmp => tmp.IdCarrera == idCarrera);

                lstCarreras.RemoveAt(indice);

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
                Carreras carreras= lstCarreras.FirstOrDefault(tmp => tmp.IdCarrera == idCarrera);

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
                return lstCarreras;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
