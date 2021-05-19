using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Sales
{
    public class DetalleVenta
    {
        public int idDetalleVenta { get; set; }
        public int idVenta { get; set; }
        public int idArticulo { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe de ingresar una cantidad")]
        public int cantidad { get; set; }

        [Display(Name = "Precio")]        
        public double precioDetalleVenta { get; set; }

        [Display(Name = "Descuento")]
        public double descuento { get; set; }
    }
}
