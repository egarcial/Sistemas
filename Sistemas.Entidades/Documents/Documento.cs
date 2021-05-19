using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Documents
{
    public class Documento
    {
        public int idTipoDocumento { get; set; }

        [Display(Name = "Tipo Documento")]
        [Required(ErrorMessage = "Debe de ingresar nombre de documento")]
        [StringLength(20, ErrorMessage = "nombre de condición no puede sobrepasar los 20 caracteres")]
        public int tipoDocumento { get; set; }
    }
}
