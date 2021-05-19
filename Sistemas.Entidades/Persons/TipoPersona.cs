using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Persons
{
    public class TipoPersona
    {
        public int idTipoPersona { get; set; }

        [Display(Name = "Tipo Persona")]
        [Required(ErrorMessage = "Debe de ingresar tipo de persona ")]
        [StringLength(50, ErrorMessage = "tipo de persona  no puede sobrepasar los 50 caracteres")]
        public string tipoPersona { get; set; }
    }
}
