using Sistemas.Entidades.WareHouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Sales
{
    public class DetalleVenta
    {
        public int idDetalleVenta { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe de ingresar una cantidad")]
        public int cantidad { get; set; }

        [Display(Name = "Precio")]
        public decimal precioDetalleVenta { get; set; }

        [Display(Name = "Descuento")]
        public decimal descuento { get; set; }

        public List<Ventas> Venta { get; set; }

        public List<Articulo> Articulos { get; set; }


    }
}
