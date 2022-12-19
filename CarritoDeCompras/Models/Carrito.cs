using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("idUsuario")]
        public Usuario Usuario { get; set;}
        
        public ICollection<Producto> Productos { get; set; }
  
        public Carrito(int idUsuario)
        {
            this.idUsuario = idUsuario;
            Total = 0;
            Cantidad= 0;
        }
    }
}
