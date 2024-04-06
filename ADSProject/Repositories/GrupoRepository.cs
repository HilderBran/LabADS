using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo
    {
        private List<Grupo> lstGrupo = new List<Grupo>
        {
            new Grupo {IdGrupo = 1, IdCarrera = 1, IdMateria = 1, IdProfesor = 1
            , Ciclo = 0124, Anio = 2024}
        };

        public int ActualizarGrupo(int idGrupo, Grupo Grupo)
        {
            try
            {
                int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);

                lstGrupo[indice] = Grupo;
                lstGrupo[indice].IdGrupo = idGrupo;

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
                if (lstGrupo.Count > 0)
                {
                    Grupo.IdGrupo = lstGrupo.Last().IdGrupo + 1;
                }
                lstGrupo.Add(Grupo);

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
                int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);

                lstGrupo.RemoveAt(indice);

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
                Grupo Grupo = lstGrupo.FirstOrDefault(tmp => tmp.IdGrupo == idGrupo);

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
                return lstGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
