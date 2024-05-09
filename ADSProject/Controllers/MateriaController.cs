using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [ApiController]
    [Route("api/materia/")]
    public class MateriaController : ControllerBase
    {
        private readonly IMateria Materia;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public MateriaController(IMateria Materia)
        {
            this.Materia = Materia;
        }
        [HttpPost("agregarMateria")]
        public ActionResult<string> AgregarMateria( Materia Materia)
        {
            try
            {
                int contador = this.Materia.AgregarMateria(Materia);

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
        [HttpPut("actualizarMateria/{idMateria}")]
        public ActionResult<string> ActualizarMateria(int idMateria, Materia Materia)
        {
            try
            {
                int contador = this.Materia.ActualizarMateria(idMateria, Materia);

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
        [HttpDelete("eliminarMateria/{idMateria}")]
        public ActionResult<string> EliminarMateria(int idMateria)
        {
            try
            {
                bool eliminado = this.Materia.EliminarMateria(idMateria);

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
        [HttpGet("obtenerMateriaPorID/{idMateria}")]
        public ActionResult<string> ObtenerMateriaPorID(int idMateria)
        {
            try
            {
                Materia Materia = this.Materia.ObtenerMateriasPorID(idMateria);

                if (Materia != null)
                {
                    return Ok(Materia);
                }
                else
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "No se encontraron datos de la Materia";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("obtenerMateria")]
        public ActionResult<List<Estudiante>> ObtenerMateria()
        {
            try
            {
                List<Materia> lstMateria = this.Materia.ObtenerTodasLasMaterias();

                return Ok(lstMateria);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
