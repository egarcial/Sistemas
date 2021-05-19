using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Conditions
{
    public class Estado
    {
        public int idEstado { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Debe de ingresar nombre de estado")]
        [StringLength(20, ErrorMessage = "nombre de estado no puede sobrepasar los 20 caracteres")]
        public string estado { get; set; }
    }
}
