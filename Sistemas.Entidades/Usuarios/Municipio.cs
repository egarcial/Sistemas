using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Usuarios
{
   public class Municipio
    {
        public int idMunicipio { get; set; }
        [Display(Name ="Municipio")]
        [Required(ErrorMessage = "Debe Ingresar nombre de Municipio")]
        [StringLength(70, ErrorMessage = "Municipio no puede sobrepasar los 50 caracteres")]
        public string nombreMunicipio { get; set; }
        [Required]
        public int idDepartamento { get; set; }
    }
}
