using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ADSProject.Models
{
    public class Carreras
    {
        public int IdCarrera { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 3, ErrorMessage = "La longitud del campo no puede ser mayor a los 3 caracteres")]
        public string CodigoCarrera { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 40, ErrorMessage = "La longitud del campo no puede ser mayor a 40 caracteres")]
        public string NombreCarrera { get; set; }

    }
}
 