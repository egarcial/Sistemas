using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Purchases
{
    public class DetalleIngreso
    {
        public int idDetalleIngreso { get; set; }
        public int idingreso { get; set; }
        public int idArticulo { get; set; }
       
        [Required(ErrorMessage = "Debe de ingresar la cantidad")]
        public int cantidad { get; set; }
        public double precioDetalle { get; set; }


    }
}
