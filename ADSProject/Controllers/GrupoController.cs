using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [ApiController]
    [Route("api/grupo/")]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupo Grupo;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public GrupoController(IGrupo Grupo)
        {
            this.Grupo = Grupo;
        }
        [HttpPost("agregarGrupo")]
        public ActionResult<string> AgregarGrupo(Grupo Grupo)
        {
            try
            {
                int contador = this.Grupo.AgregarGrupo(Grupo);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Ocurrio un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("actualizarGrupo/{idGrupo}")]
        public ActionResult<string> ActualizarGrupo(int idGrupo, Grupo Grupo)
        {
            try
            {
                int contador = this.Grupo.ActualizarGrupo(idGrupo, Grupo);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro acuatilzado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("eliminarGrupo/{idGrupo}")]
        public ActionResult<string> EliminarGrupo(int idGrupo)
        {
            try
            {
                bool eliminado = this.Grupo.EliminarGrupo(idGrupo);

                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("obtenerGrupoPorID/{idGrupo}")]
        public ActionResult<string> ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                Grupo Grupo = this.Grupo.ObtenerGruposPorID(idGrupo);

                if (Grupo != null)
                {
                    return Ok(Grupo);
                }
                else
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "No se encontraron datos de la Grupo";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("obtenerGrupo")]
        public ActionResult<List<Estudiante>> ObtenerGrupo()
        {
            try
            {
                List<Grupo> lstGrupo = this.Grupo.ObtenerTodosLosGrupos();

                return Ok(lstGrupo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
