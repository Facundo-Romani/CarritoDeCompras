using CarritoDeCompras.Models;
using Microsoft.EntityFrameworkCore;

namespace CarritoDeCompras.Context
{
    public class DbContextCarrito : DbContext
    {
        public DbContextCarrito(DbContextOptions<DbContextCarrito> options) : base(options)
        {

        }

        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarroPromocional> CarrosPromocionales { get; set; }
        public DbSet<CarroVip> CarrosVips { get; set; }
        public DbSet<FechaPromocional> FechasPromocionales { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrito>().ToTable("Carrito");
            modelBuilder.Entity<CarroPromocional>().ToTable("CarroPromocional");
            modelBuilder.Entity<CarroVip>().ToTable("CarroVip");
            modelBuilder.Entity<FechaPromocional>().ToTable("FechaPromocional");
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}
