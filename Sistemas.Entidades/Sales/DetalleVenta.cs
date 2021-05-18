using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Entidades.Sales
{
    public class DetalleVenta
    {
        public int idDetalleVenta { get; set; }
        public int idVenta { get; set; }
        public int idArticulo { get; set; }
        public int cantidad { get; set; }
        public double precioDetalleVenta { get; set; }
        public double descuento { get; set; }
    }
}
