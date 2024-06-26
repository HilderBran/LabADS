﻿using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    public class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "la longitud del campo no puede ser mayor a 50 caracteres")]
        public string NombresEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "la longitud del campo no puede ser mayor a 50 caracteres")]
        public string ApellidosEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MinLength(length: 12, ErrorMessage = "la longitud del campo no puede ser menor a 12 caracteres")]
        [MaxLength(length: 50, ErrorMessage = "la longitud del campo no puede ser mayor a 50 caracteres")]
        public string CodigoEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 254, ErrorMessage = "la longitud del campo no puede ser mayor a 254 caracteres")]
        [EmailAddress(ErrorMessage = "El formato de correo electronico no es correcto")]
        public string CorreoEstudiante { get; set; }
    }
}
