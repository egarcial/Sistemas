using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Purchases
{
    public class Ingreso
    {
        public int idIngreso { get; set; }
        public int idProveedor { get; set; }
        public int idUsuario { get; set; }
        public int idTipoComprobante { get; set; }

        [Display(Name = "Serie  Comprobante")]
        [Required(ErrorMessage = "Debe de ingresar serie de comprobante")]
        [StringLength(7, ErrorMessage = "Serie de comrpobante  no puede sobrepasar los 7 caracteres")]
        public string serieComprobante { get; set; }

        [Display(Name = "Número  Comprobante")]
        [Required(ErrorMessage = "Debe de ingresar número de comprobante")]
        [StringLength(10, ErrorMessage = "numero de comprobante no puede sobrepasar los 10 caracteres")]
        public string numComprobante { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Debe de ingresar fecha")]
        public string fechaHora { get; set; }

        [Display(Name = "Impuesto")]
        public double impuesto { get; set; }

        [Display(Name = "Total")]
        public double total { get; set; }
        public int idEstado { get; set; }
    }
}
