using Sistemas.Entidades.Conditions;
using Sistemas.Entidades.Documents;
using Sistemas.Entidades.Persons;
using Sistemas.Entidades.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Purchases
{
    public class Ingreso
    {
        public int idIngreso { get; set; }

        [Display(Name = "Serie  Comprobante")]
        [Required(ErrorMessage = "Debe de ingresar serie de comprobante")]
        [StringLength(7, ErrorMessage = "Serie de comrpobante  no puede sobrepasar los 7 caracteres")]
        public string serieComprobante { get; set; }

        [Display(Name = "Número  Comprobante")]
        [Required(ErrorMessage = "Debe de ingresar número de comprobante")]
        [StringLength(10, ErrorMessage = "numero de comprobante no puede sobrepasar los 10 caracteres")]
        public string numComprobante { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Debe de ingresar fecha")]
        public DateTime fechaHora { get; set; }

        [Display(Name = "Impuesto")]
        public decimal impuesto { get; set; }

        [Display(Name = "Total")]
        public decimal total { get; set; }

        public List<Persona> PersonaProveedor { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public List<Comprobante> Comprobantes { get; set; }

        public List<Estado> Estados { get; set; }

    }
}
