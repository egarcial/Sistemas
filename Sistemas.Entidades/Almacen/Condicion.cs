﻿using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.Almacen
{
    public class Condicion
    {
        public int idCondicion { get; set; }

        [Display(Name = "Condicion")]
        [Required(ErrorMessage = "Debe de ingresar nombre de condición")]
        [StringLength(20, ErrorMessage = "nombre de condición no puede sobrepasar los 20 caracteres")]
        public string condicion { get; set; }

    }
}
