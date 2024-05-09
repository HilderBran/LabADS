using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Database;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo
    {
        /*private List<Grupo> lstGrupo = new List<Grupo>
        {
            new Grupo {IdGrupo = 1, IdCarrera = 1, IdMateria = 1, IdProfesor = 1
            , Ciclo = 0124, Anio = 2024}
        };*/

        private readonly ApplicationDBContext applicationDBContext;

        public GrupoRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public int ActualizarGrupo(int idGrupo, Grupo Grupo)
        {
            try
            {
                /*int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);

                lstGrupo[indice] = Grupo;
                lstGrupo[indice].IdGrupo = idGrupo;*/

                var item = applicationDBContext.grupos.FirstOrDefault(x => x.IdGrupo == idGrupo);

                applicationDBContext.Entry(item).CurrentValues.SetValues(Grupo);

                applicationDBContext.SaveChanges();

                return idGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarGrupo(Grupo Grupo)
        {
            try
            {
                /*if (lstGrupo.Count > 0)
                {
                    Grupo.IdGrupo = lstGrupo.Last().IdGrupo + 1;
                }
                lstGrupo.Add(Grupo);*/

                applicationDBContext.grupos.Add(Grupo);
                applicationDBContext.SaveChanges();

                return Grupo.IdGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                /*int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);*/

                var item = applicationDBContext.grupos.FirstOrDefault(x => x.IdGrupo == idGrupo);

                applicationDBContext.grupos.Remove(item);

                applicationDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Grupo ObtenerGruposPorID(int idGrupo)
        {
            try
            {
                //Grupo Grupo = lstGrupo.FirstOrDefault(tmp => tmp.IdGrupo == idGrupo);

                Grupo Grupo = applicationDBContext.grupos.FirstOrDefault(x => x.IdGrupo == idGrupo);

                return Grupo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Grupo> ObtenerTodosLosGrupos()
        {
            try
            {
                //return lstGrupo;

                return applicationDBContext.grupos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
