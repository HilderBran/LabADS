using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class CarrerasBase1
    {
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "la longitud del campo no puede ser mayor a 50 caracteres")]
        public string CodigoCarrera { get; set; }
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 3, ErrorMessage = "la longitud del campo no puede ser mayor a 3 caracteres")]
        public string NombreCarrera { get; set; }
    }
}