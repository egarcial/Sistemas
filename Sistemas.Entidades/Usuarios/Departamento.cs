using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Usuarios
{
   public class Departamento
    {
        public int idDepatamento { get; set; }

        [Display(Name ="Nombre Departamento")]
        [Required (ErrorMessage ="Deberá ingresar nombre del departamento")]
        [StringLength(50, ErrorMessage = "Nombre del departamento sobrepasar los 50 numeros")]
        public string nombreDepartamento { get; set; }

    }
}
