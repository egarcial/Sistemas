using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Entidades.Purchases
{
    public class DetalleIngreso
    {
        public int idDetalleIngreso { get; set; }
        public int idingreso { get; set; }
        public int idArticulo { get; set; }
        public int cantidad { get; set; }
        public double precioDetalle { get; set; }


    }
}
