using Sistemas.Entidades.Conditions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.WareHouse
{
    public class Articulo
    {
        public int idArticulo { get; set; }

  
        [Display(Name = "Código Producto")]
        [Required(ErrorMessage = "Ingrese código del artículo")]
        [StringLength(50, ErrorMessage = "Código no puede sobrepasar los 50 numeros")]
        public string codigo { get; set; }

        [Display(Name = "Nombre del Articulo")]
        [Required(ErrorMessage = "Deberá ingresar nombre del Artículo")]
        [StringLength(50, ErrorMessage = "Nombre no puede sobrepasar los 50 numeros")]
        public string nombre { get; set; }

        public decimal precioVenta { get; set; }

        public int stock { get; set; }

        [Display(Name = "Nombre del Articulo")]
        [StringLength(256, ErrorMessage = "Nombre no puede sobrepasar los 50 numeros")]
        public string descripcion { get; set; }


        public List<Categoria> Categorias { get; set; }
       
        public List<Condicion> Condiciones { get; set; }

    }
}
