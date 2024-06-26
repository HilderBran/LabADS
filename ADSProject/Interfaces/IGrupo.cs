﻿using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IGrupo
    {
        public int AgregarGrupo(Grupo Grupo);
        public int ActualizarGrupo(int idGrupo, Grupo Grupo);
        public bool EliminarGrupo(int idGrupo);
        public List<Grupo> ObtenerTodosLosGrupos();
        public Grupo ObtenerGruposPorID(int idGrupo);
    }
}
