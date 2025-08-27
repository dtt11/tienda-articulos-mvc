using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TiendaMVC.Models
{
    /*
       Clase usada para capturar los datos del formulario de productos.
    */

    public class ProductoDto
    {
        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Marca { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Categoria { get; set; } = string.Empty;
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Descripcion { get; set; } = string.Empty;
        public IFormFile? ProductoImagen { get; set; } 
        //Es una propiedad opcional, no obligatoria

    }
}
