using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Documents
{
    public class Comprobante
    {
        public int idTipoComprobante { get; set; }

        [Display(Name = "Comprobante")]
        [Required(ErrorMessage = "Debe de ingresar nombre de comprobante")]
        [StringLength(20, ErrorMessage = "nombre de comprobante no puede sobrepasar los 20 caracteres")]
        public string tipoComprobante { get; set; }

    }
}
