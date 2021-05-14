using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Entidades.Almacen
{
    public class Articulo
    {
        public int idArticulo { get; set; }
        public int  idCategoria { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public double precioVenta { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public int idCondicion { get; set; }
    }
}
