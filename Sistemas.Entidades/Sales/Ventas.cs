using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Entidades.Sales
{
    public class Ventas
    {
        public int idVenta { get; set; }
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        public int idTipoComprobante { get; set; }
        public string serieComprobante { get; set; }
        public string numComprobante { get; set; }
        public string fechaHora { get; set; }
        public double impuesto { get; set; }
        public double total { get; set; }
        public int idEstado { get; set; }
    }
}
