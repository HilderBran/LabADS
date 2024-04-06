using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
        private List<Materia> lstMateria = new List<Materia>
        {
            new Materia {IdMateria = 1, NombreMateria= "ESTATICA"}
        };

        public int ActualizarMateria(int idMateria, Materia Materia)
        {
            try
            {
                int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);

                lstMateria[indice] = Materia;
                lstMateria[indice].IdMateria = idMateria;

                return idMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarMateria(Materia Materia)
        {
            try
            {
                if (lstMateria.Count > 0)
                {
                    Materia.IdMateria = lstMateria.Last().IdMateria + 1;
                }
                lstMateria.Add(Materia);

                return Materia.IdMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);

                lstMateria.RemoveAt(indice);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Materia ObtenerMateriasPorID(int idMateria)
        {
            try
            {
                Materia Materia = lstMateria.FirstOrDefault(tmp => tmp.IdMateria == idMateria);

                return Materia;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            try
            {
                return lstMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
