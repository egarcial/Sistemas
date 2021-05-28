using Sistemas.Entidades.Conditions;
using Sistemas.Entidades.Documents;
using Sistemas.Entidades.Persons;
using Sistemas.Entidades.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Sales
{
    public class Ventas
    {
        public int idVenta { get; set; }

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
        public DateTime fechaHora { get; set; }

        [Display(Name = "Impuesto")]
        public decimal impuesto { get; set; }

        [Display(Name = "Total")]
        public decimal total { get; set; }

        public List<Persona> PersonaCliente { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public List<Comprobante> Comprobantes { get; set; }

        public List<Estado> Estados { get; set; }

    }
}
