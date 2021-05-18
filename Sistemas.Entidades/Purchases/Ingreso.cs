using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Entidades.Purchases
{
    public class Ingreso
    {
        public int idIngreso { get; set; }
        public int idProveedor { get; set; }
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
