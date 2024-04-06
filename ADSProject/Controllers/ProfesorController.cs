using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/profesores/")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesor Profesor;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public ProfesorController(IProfesor profesor)
        {
            this.Profesor = Profesor;
        }
        [HttpPost("agregarEstudainte")]
        public ActionResult<string> AgregarProfesor([FromBody] Profesor Profesor)
        {
            try
            {
                int contador = this.Profesor.AgregarProfesor(Profesor);

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
        [HttpPost("actualizarProfesor/{idProfesor}")]
        public ActionResult<string> ActualizarProfesor(int idProfesor, [FromBody] Profesor Profesor)
        {
            try
            {
                int contador = this.Profesor.ActualizarProfesor(idProfesor, Profesor);

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
        [HttpDelete("eliminarProfesor/{idProfesor}")]
        public ActionResult<string> EliminarProfesor(int idProfesor)
        {
            try
            {
                bool eliminado = this.Profesor.EliminarProfesor(idProfesor);

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
        [HttpGet("obtenerProfesorPorID/{idProfesor}")]
        public ActionResult<string> ObtenerProfesorPorID(int idProfesor)
        {
            try
            {
                Profesor Profesor = this.Profesor.ObtenerProfesoresPorID(idProfesor);

                if (Profesor != null)
                {
                    return Ok(Profesor);
                }
                else
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "No se encontraron datos del Profesor";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("obtenerProfesor")]
        public ActionResult<List<Profesor>> ObtenerProfesor()
        {
            try
            {
                List<Profesor> lstProfesor = this.Profesor.ObtenerTodosLosProfesores();

                return Ok(lstProfesor);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

