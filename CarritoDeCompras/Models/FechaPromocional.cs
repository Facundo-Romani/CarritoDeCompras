using System.ComponentModel.DataAnnotations;

namespace CarritoDeCompras.Models
{
    public class FechaPromocional
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public DateTime FechaDesde { get; set; }
        
        [Required]
        public DateTime FechaHasta { get; set; }

    }
}
