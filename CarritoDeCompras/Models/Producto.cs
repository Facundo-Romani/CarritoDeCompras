using System.ComponentModel.DataAnnotations;

namespace CarritoDeCompras.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public decimal Precio { get; set;  }
    }
}
