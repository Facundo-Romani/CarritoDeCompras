using System.ComponentModel.DataAnnotations;

namespace CarritoDeCompras.Models
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal totalDescuento { get; set;}

        // Prop Navegación.
        public int idUsuario { get; set; }
        
        public Usuario Usuario { get; set;}

        public int idProducto { get; set; }
        
        public ICollection<Producto> Productos { get; set; }

       
        public Carrito(int idUsuario)
        {
            this.idUsuario = idUsuario;
            Total = 0;
            Cantidad= 0;
        }
    }
}
