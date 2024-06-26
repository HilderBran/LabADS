﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models;

public class Profesor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdProfesor { get; set; }
    [Required(ErrorMessage = "Este es un campo requerido")]
    [MaxLength(length: 50, ErrorMessage = "la longitud del campo no puede ser mayor a 50 caracteres")]
    public string NombreProfesor { get; set; }
    [Required(ErrorMessage = "Este es un campo requerido")]
    [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres")]
    public string ApellidoProfesor { get; set; }
    [Required(ErrorMessage = "Este es un campo requerido")]
    [MaxLength(length: 254, ErrorMessage = "La longitud del campo no puede ser mayor a 254 caracteres")]
    public string Email {  get; set; }
}
