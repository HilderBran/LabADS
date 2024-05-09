using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Database;

namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
       /* private List<Materia> lstMateria = new List<Materia>
        {
            new Materia {IdMateria = 1, NombreMateria= "ESTATICA"}
        };*/
       private readonly ApplicationDBContext applicationDBContext;

        public MateriaRepository(ApplicationDBContext applicationDBContext)
        {

            this.applicationDBContext = applicationDBContext;
        }

        public int ActualizarMateria(int idMateria, Materia Materia)
        {
            try
            {
               /* int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);

                lstMateria[indice] = Materia;
                lstMateria[indice].IdMateria = idMateria;*/
              var item = applicationDBContext.materias.SingleOrDefault(x => x.IdMateria == idMateria);
                applicationDBContext.Entry(item).CurrentValues.SetValues(Materia);
                applicationDBContext.SaveChanges();

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
                /*if (lstMateria.Count > 0)
                {
                    Materia.IdMateria = lstMateria.Last().IdMateria + 1;
                }
                lstMateria.Add(Materia);*/
                applicationDBContext.materias.Add(Materia);
                applicationDBContext.SaveChanges();

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
                /*int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);

                lstMateria.RemoveAt(indice);*/

                var item = applicationDBContext.materias.SingleOrDefault(x => x.IdMateria == idMateria);
                applicationDBContext.materias.Remove(item);
                applicationDBContext.SaveChanges();

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
               // Materia Materia = lstMateria.FirstOrDefault(tmp => tmp.IdMateria == idMateria);
               var materia= applicationDBContext.materias.SingleOrDefault(x => x.IdMateria == idMateria);

                return materia;
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
                //return lstMateria;
                return applicationDBContext.materias.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
