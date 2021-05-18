using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.Users
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        [Display(Name = "Nombre de Categoria")]
        [Required(ErrorMessage = "Nombre de Catergoria es obligatorio!!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Nombre debe comprender entre un minimo de 4 y máximo 100 carateres")]
        public string nombre { get; set; }

        [Display(Name = "Tipo Documento")]
        public string tipoDocumento { get; set; }

        [Display(Name = "Número Documento")]
        public int numDocumento { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "la dirección es obligatoria")]
        [StringLength(70, MinimumLength = 25, ErrorMessage = "Dirección debe de comprender entre un minimo 25 y máximo 70 caracteres")]
        public string direccion { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Número de télefono es obligatorio")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [StringLength(11, ErrorMessage = "Número de teléfono de tener 11 números")]
        public string telefono { get; set; }

        [Display(Name = "Correo Electrónico:")]
        [Required(ErrorMessage = "Debe ingresar un correo electrónico")]
        [EmailAddress(ErrorMessage = "Favor introduzca un correo electrónico valido!!")]
        public string email { get; set; }

        [Display(Name = "Contraseña Hash")]
        [Required]
        [StringLength(64)]
        public string passwordHash { get; set; }

        [Display(Name = "Contraseña Salt")]
        [Required]
        [StringLength(64)]
        public string passwordSalt { get; set; }

        public bool condicion { get; set; }
    }
}
