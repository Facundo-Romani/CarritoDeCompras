using CarritoDeCompras.Context;
using CarritoDeCompras.Models;
using CarritoDeCompras.Services.ServicesContract;

namespace CarritoDeCompras.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbContextCarrito _context;

        public UsuarioService(DbContextCarrito context)
        {
            _context = context;
        }

        public Usuario CrearUsuario(Usuario obj)
        {
            _context.Usuarios.Add(obj);
            _context.SaveChanges();

            return obj;
        }
    }
}
