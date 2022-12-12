using System.ComponentModel.DataAnnotations;

namespace CarritoDeCompras.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Email { get; set; }
        
        [Required]
        public string? Password { get; set; }
        
        [Required]
        public int Dni { get; set; }
        
        [Required]
        public bool Vip { get; set; } = false;

    }
}
