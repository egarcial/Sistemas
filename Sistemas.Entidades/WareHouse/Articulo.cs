using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.WareHouse
{
    public class Articulo
    {
        public int idArticulo { get; set; }

        [Required(ErrorMessage = "Ingrese tipo de categoria")]
        public int idCategoria { get; set; }

        [Display(Name = "Código Producto")]
        [Required(ErrorMessage = "Ingrese código del artículo")]
        [StringLength(50, ErrorMessage = "Código no puede sobrepasar los 50 numeros")]
        public string codigo { get; set; }

        [Display(Name = "Nombre del Articulo")]
        [Required(ErrorMessage = "Deberá ingresar nombre del Artículo")]
        [StringLength(50, ErrorMessage = "Nombre no puede sobrepasar los 50 numeros")]
        public string nombre { get; set; }
        public double precioVenta { get; set; }
        public int stock { get; set; }

        [Display(Name = "Nombre del Articulo")]
        [StringLength(256, ErrorMessage = "Nombre no puede sobrepasar los 50 numeros")]
        public string descripcion { get; set; }
        public int idCondicion { get; set; }
    }
}
