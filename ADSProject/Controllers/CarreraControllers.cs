using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ADSProject.Controllers
{
    [Route("api/carreras/")]

    public class CarreraControllers : ControllerBase
    {
        private readonly ICarreras carreras;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public CarreraControllers(ICarreras carreras)
        {
            this.carreras = carreras;
        }
        [HttpPost("agregarCarrera")]
        public ActionResult<string> AgregarCarrera([FromBody] Carreras carreras)
        {
            try
            {
                int contador = this.carreras.AgregarCarrera(carreras);

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
        [HttpPost("actualizarCarrera/{idCarrera}")]
        public ActionResult<string> ActualizarCarrera(int idCarrera, [FromBody] Carreras carreras)
        {
            try
            {
                int contador = this.carreras.ActualizarCarrera(idCarrera, carreras);

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
        [HttpDelete("eliminarCarrera/{idCarrera}")]
        public ActionResult<string> EliminarCarrera(int idCarrera)
        {
            try
            {
                bool eliminado = this.carreras.EliminarCarrera(idCarrera);

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
        [HttpGet("obtenerCarreraPorID/{idCarrera}")]
        public ActionResult<string> ObtenerCarreraPorID(int idCarrera)
        {
            try
            {
                Carreras carreras= this.carreras.ObtenerCarreraPorID(idCarrera);

                if (carreras != null)
                {
                    return Ok(carreras);
                }
                else
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "No se encontraron datos de la carrera";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("obtenerCarreras")]
        public ActionResult<List<Estudiante>> ObtenerCarreras()
        {
            try
            {
                List<Carreras> lstCarreras = this.carreras.ObtenerTodasLasCarreras();

                return Ok(lstCarreras);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
