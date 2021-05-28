using Sistemas.Entidades.WareHouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Purchases
{
    public class DetalleIngreso
    {
        public int idDetalleIngreso { get; set; }
       
        [Required(ErrorMessage = "Debe de ingresar la cantidad")]
        public int cantidad { get; set; }

        public decimal precioDetalle { get; set; }

        public List<Ingreso> Ingresos { get; set; }

        public List<Articulo> Articulos { get; set; }

    }
}
