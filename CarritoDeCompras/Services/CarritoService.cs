using CarritoDeCompras.Context;
using CarritoDeCompras.Models;
using CarritoDeCompras.Services.ServicesContract;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CarritoDeCompras.Services
{
    public class CarritoService : ICarritoService
    {
        private readonly DbContextCarrito _context;
        private readonly ITipoDescuentoCarrito _totalDescuento;

        public CarritoService(DbContextCarrito context, ITipoDescuentoCarrito totalDescuento)
        {
            _context = context;
            _totalDescuento = totalDescuento;
        }


        public Carrito CrearCarrito(int dni)
        {
            // Falta determinar el tipo de carrito antes de crear.
            var dniUsuario = _context.Usuarios.Where(u => u.Dni == dni).Select(u => u.Id).FirstOrDefault();

            try
            {
                var nuevoCarrito = new Carrito(dniUsuario);

                _context.Carritos.Add(nuevoCarrito);
                _context.SaveChanges();

                return nuevoCarrito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DeleteCarrito(int id)
        {
            var carrito = _context.Carritos.FirstOrDefault(c => c.Id == id);

            if (carrito != null)
            {
                _context.Carritos.Remove(carrito);
                _context.SaveChanges();
            }
        }


        public Carrito AddProducto(int idProducto, int idCarrito)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id == idProducto);
            var carrito = _context.Carritos.FirstOrDefault(c => c.Id == idCarrito);

            carrito.Productos.Add(producto);

            carrito.Total += producto.Precio;
            _totalDescuento.CalcularDescuento(carrito);

            _context.Carritos.Update(carrito);
            _context.SaveChanges();

            return carrito;
        }


        public Carrito DeleteProductoCarrito(int idProducto, int idCarrito)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id == idProducto);
            var carrito = _context.Carritos.FirstOrDefault(c => c.Id == idCarrito);

            carrito.Productos.Remove(producto);
            carrito.Total -= producto.Precio;

            _context.Carritos.Update(carrito);
            _context.SaveChanges();

            return carrito;
        }

    }
}
