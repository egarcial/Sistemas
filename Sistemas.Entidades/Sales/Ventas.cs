using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Sales
{
    public class Ventas
    {
        public int idVenta { get; set; }
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        public int idTipoComprobante { get; set; }

        [Display(Name = "Serie de comprobante")]
        [Required(ErrorMessage = "Debe de ingresar serie de comprobante")]
        [StringLength(10, ErrorMessage = "serie de comprobante no puede sobrepasar los 510 caracteres")]
        public string serieComprobante { get; set; }

        [Display(Name = "Número  Comprobante")]
        [Required(ErrorMessage = "Debe de ingresar serie de comprobante")]
        [StringLength(10, ErrorMessage = "Número de comprobante  no puede sobrepasar los 50 caracteres")]
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
